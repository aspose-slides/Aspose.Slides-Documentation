---
title: プレゼンテーション画像コレクション内の画像を置き換える
type: docs
weight: 80
url: /php-java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Javaは、スライドのシェイプ内の画像を置き換えることを可能にします。この記事では、異なるアプローチを使用してプレゼンテーション画像コレクションに追加された画像を置き換える方法を説明します。

{{% /alert %}} 
## **プレゼンテーション画像コレクション内の画像の置き換え**
Aspose.Slides for PHP via Javaは、プレゼンテーション画像コレクション内の画像を置き換えるためのシンプルなAPIメソッドを提供しています。以下の手順に従ってください：

1. Presentationクラスを使用して、画像が含まれているプレゼンテーションファイルをロードします。
1. バイト配列でファイルから画像をロードします。
1. ターゲット画像をバイト配列内の新しい画像で置き換えます。
1. 2番目のアプローチでは、Imageオブジェクトに画像をロードし、ロードされた画像でターゲット画像を置き換えます。
1. 3番目のアプローチでは、プレゼンテーション画像コレクションにすでに追加された画像で画像を置き換えます。
1. 修正されたプレゼンテーションをPPTXファイルとして書き込みます。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplaceImage-ReplaceImage.java" >}}