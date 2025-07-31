---
name: Bug report
about: Create a report to help us improve
title: "[BUG]"
labels: bug
assignees: vpenades

---

**Before submitting a bug**

It is fairly common that model loading issues are produced by malformed glTF files, so YOU MUST check the model you're trying to load with glTF Validator before submitting a bug report.

    https://github.khronos.org/glTF-Validator

- If glTF Validator reports the model has errors, then you must report the problem to the owner of the exporter, _not here_.
- If glTF Validator reports no errors, then you can proceed to report the issue here.

I also recomend to preview the model using  https://sandbox.babylonjs.com  to ensure the model looks correct. Some tools like Windows viewer or Blender Importer have issues with some models and might mislead into thinking the model is wrong.

Any questions related to DRACO compression or MeshOpt Compression need to be asked in [this discussion thread](https://github.com/vpenades/SharpGLTF/discussions/235)

When asking about examples on how to do this or that, please, review the Unit Tests of the repository, there's plenty of examples on how to do almost everything.

**Describe the bug**
A clear and concise description of what the bug is.

**To Reproduce**
If the issue is complex, or depends on loading or processing a specific model, provide a demo and the models required, otherwise it will take a lot longer to fix.

**please complete the following information:**
 - OS: [e.g. iOS]
 - SharpGLTF Version [e.g. SharpGLTF-1.0.5, or From Source]
