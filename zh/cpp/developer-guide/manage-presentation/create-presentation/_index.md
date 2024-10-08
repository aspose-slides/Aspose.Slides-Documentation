---
title: 创建演示文稿 - C++ PowerPoint API
linktitle: 创建演示文稿
type: docs
weight: 10
url: /cpp/create-presentation/
description: 要在 C++ API 中创建 PowerPoint 演示文稿，请按照本文中提到的步骤操作。代码将一条线添加到演示文稿的第一张幻灯片上。
---

## **创建 PowerPoint 演示文稿**
要在选定的演示文稿幻灯片上添加一条简单的纯线，请按照以下步骤操作：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 Shapes 对象公开的 AddAutoShape 方法添加一条线类型的 AutoShape。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们已将一条线添加到演示文稿的第一张幻灯片上。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}