---
title: 打开演示文稿
type: docs
weight: 20
url: /python-net/open-presentation/
keywords: "打开 PowerPoint, PPTX, PPT, 打开演示文稿, 加载演示文稿, Python"
description: "在 Python 中打开或加载演示文稿 PPT, PPTX, ODP"
---

除了从头创建 PowerPoint 演示文稿外，Aspose.Slides 还允许您打开现有的演示文稿。加载演示文稿后，您可以获取演示文稿的信息，编辑演示文稿（幻灯片上的内容），添加新幻灯片或删除现有幻灯片等。

## 打开演示文稿

要打开现有的演示文稿，您只需实例化 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类，并将文件路径（要打开的演示文稿的路径）传递给它的构造函数。

以下 Python 代码演示了如何打开演示文稿并查找其包含的幻灯片数量：

```python
import aspose.slides as slides

# 实例化 Presentation 类，并将文件路径传递给它的构造函数
with slides.Presentation("pres.pptx") as pres:
    # 打印演示文稿中幻灯片的总数
    print(pres.slides.length)
```

## **打开受密码保护的演示文稿**

当您需要打开受密码保护的演示文稿时，可以通过 `password` 属性（来自 [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) 类）传递密码，以解密演示文稿并加载它。以下 Python 代码演示了该操作：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "PASSWORD"
with slides.Presentation("pres.pptx", load_options) as pres:
    ...
```

## 打开大演示文稿

Aspose.Slides 提供了选项（尤其是 [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) 类中的 `blob_management_options` 属性），以允许您加载大型演示文稿。

以下 Python 代码演示了加载一个大型演示文稿（例如 2GB 大小）的操作：

```python
import aspose.slides as slides
import os

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("pres.pptx", loadOptions) as pres:
    # 大型演示文稿已加载，可以使用，但内存消耗仍然较低。

    # 对演示文稿进行更改。
    pres.slides[0].name = "非常大的演示文稿"

    # 演示文稿将保存到其他文件。在操作过程中内存消耗保持较低
    pres.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # 不可以这样做！会抛出 IO 异常，因为文件在 pres 对象未被处理时是锁定状态
    os.remove("pres.pptx")

# 在这里这样做是可以的。源文件没有被 pres 对象锁定。
os.remove("pres.pptx")
```

{{% alert color="info" title="信息" %}}

为了绕过与流交互时的某些限制，Aspose.Slides 可能会复制流的内容。通过流加载大型演示文稿将导致演示文稿内容的复制，并造成加载速度缓慢。因此，当您打算加载大型演示文稿时，我们强烈建议您使用演示文稿文件路径，而不是其流。

当您想创建包含大型对象（视频、音频、大图像等）的演示文稿时，可以使用 [Blob 功能](https://docs.aspose.com/slides/python-net/manage-blob/) 来减少内存消耗。

{{%/alert %}} 


## 加载演示文稿

Aspose.Slides 提供了 [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/)，其中包含一个方法以允许您管理外部资源。以下 Python 代码演示了如何使用 `IResourceLoadingCallback` 接口：

```python
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

<h2>打开和保存演示文稿</h2>

<a name="python-net-open-save-presentation"><strong>步骤：在 Python 中打开和保存演示文稿</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例，并传递要打开的文件。
2. 保存演示文稿。

```python
import aspose.slides as slides

# 实例化一个表示 PPT 文件的 Presentation 对象
with slides.Presentation() as presentation:
    
    #...在这里做一些工作...

    # 将演示文稿保存到文件
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```