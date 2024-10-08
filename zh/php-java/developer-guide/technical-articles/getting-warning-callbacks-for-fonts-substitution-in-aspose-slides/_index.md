---
title: 获取 Aspose.Slides 中字体替代的警告回调
type: docs
weight: 90
url: /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

通过 Java 的 Aspose.Slides for PHP 使得在渲染过程中如果所用字体在机器上不可用时能够获取字体替代的警告回调。这些警告回调在调试渲染过程中缺失或不可访问字体的问题时非常有帮助。



{{% /alert %}} 

通过 Java 的 Aspose.Slides for PHP 提供了一个简单的 API 方法来在渲染过程中接收警告回调。请按照以下步骤配置警告回调：

1. 创建一个自定义回调类以接收回调。
1. 使用 LoadOptions 类设置警告回调。
1. 加载一个在目标机器上不可用字体的演示文稿文件。
1. 生成幻灯片缩略图以查看效果。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}