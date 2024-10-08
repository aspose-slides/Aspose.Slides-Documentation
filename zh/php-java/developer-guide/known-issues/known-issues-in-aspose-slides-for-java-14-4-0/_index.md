---
title: Aspose.Slides for PHP via Java 14.4.0 中已知问题
type: docs
weight: 30
url: /php-java/known-issues-in-aspose-slides-for-java-14-4-0/
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 14.4.0 提供了对 PowerPoint 文档处理的新决策。存在一些限制和已知问题，预计将在未来的版本中消除：

- 某些形状在序列化的 PPT 文档中几何形状错误（弧形、圆形箭头、呼叫框）。
- 并非所有 PPTX 文本格式化功能都支持在 PPT 序列化（制表符、缩进和段落格式化限制）。
- 序列化的 PPT 文档中没有文本语言和拼写设置的信息。
- 并非所有 PPTX 主题功能都支持在 PPT 序列化（仅支持填充格式、线格式和字体的序列化）。
- OLE/ActiveX PPT 序列化到 PPT 存在已知问题。
- 不支持 WordArt 序列化和渲染。

{{% /alert %}}