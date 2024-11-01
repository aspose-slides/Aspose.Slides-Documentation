---
title: 在Aspose.Slides中获取字体替换的警告回调
type: docs
weight: 90
url: /zh/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for Java 使得在渲染过程中，如果所使用的字体在机器上不可用，可以获取字体替换的警告回调。这些警告回调有助于调试渲染过程中缺失或不可访问字体的问题。

{{% /alert %}} 

Aspose.Slides for Java 提供了简单的 API 方法，在渲染过程中接收警告回调。请按照以下步骤配置警告回调：

1. 创建一个自定义回调类以接收回调。
1. 使用 LoadOptions 类设置警告回调
1. 加载一个在目标机器上不可用字体的演示文件。
1. 生成幻灯片缩略图以查看效果。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}