---
title: 检查演示文稿
type: docs
weight: 30
url: /zh/java/examine-presentation/
keywords:
- PowerPoint
- 演示文稿
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- PPTX
- PPT
- Java
description: "在Java中读取和修改PowerPoint演示文稿属性"
---

Aspose.Slides for Java 允许您检查演示文稿以了解其属性并理解其行为。

{{% alert title="信息" color="info" %}}

[PresentationInfo](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo) 和 [DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/) 类包含在此操作中使用的属性和方法。

{{% /alert %}}

## **检查演示文稿格式**

在处理演示文稿之前，您可能想要了解该演示文稿目前的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查演示文稿的格式。请看以下Java代码：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
System.out.println(info.getLoadFormat()); // PPTX

IPresentationInfo info2 = PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
System.out.println(info2.getLoadFormat()); // PPT

IPresentationInfo info3 = PresentationFactory.getInstance().getPresentationInfo("pres.odp");
System.out.println(info3.getLoadFormat()); // ODP
```

## **获取演示文稿属性**

以下Java代码展示了如何获取演示文稿属性（有关演示文稿的信息）：

```java
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
IDocumentProperties props = info.readDocumentProperties();
System.out.println(props.getCreatedTime());
System.out.println(props.getSubject());
System.out.println(props.getTitle());
// ..
```

您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/documentproperties/#DocumentProperties--) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/java/com.aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，允许您对演示文稿属性进行更改。

假设我们有一个PowerPoint演示文稿，其文档属性如下所示。

![PowerPoint演示文稿的原始文档属性](input_properties.png)

此代码示例展示了如何编辑某些演示文稿属性：

```java
String fileName = "sample.pptx";

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo(fileName);

IDocumentProperties properties = info.readDocumentProperties();
properties.setTitle("我的标题");
properties.setLastSavedTime(new Date());

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

更改文档属性的结果如下所示。

![PowerPoint演示文稿的更改后的文档属性](output_properties.png)

## **有用的链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接有用：

- [检查演示文稿是否加密](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否为只读（写保护）](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [在加载演示文稿之前检查其是否受密码保护](https://docs.aspose.com/slides/java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).