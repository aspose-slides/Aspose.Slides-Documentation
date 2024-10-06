---
title: スライド上の図形のサイズ変更
type: docs
weight: 110
url: /ja/java/re-sizing-shapes-on-slide/
---

## **スライド上の図形のサイズ変更**
Aspose.Slides for Javaの顧客から最も頻繁に寄せられる質問の1つは、スライドのサイズが変更されたときにデータが切り取られないように図形のサイズを変更する方法です。この短い技術的ヒントでは、それを達成する方法を示します。

図形の方向を誤らせないためには、スライド上の各図形を新しいスライドサイズに応じて更新する必要があります。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

スライドにテーブルがある場合、上記のコードは完璧には機能しません。その場合、テーブルの各セルをサイズ変更する必要があります。

{{% /alert %}} 

テーブル付きのスライドをサイズ変更する必要がある場合は、以下のコードを使用する必要があります。テーブルの幅や高さを設定することは、個々の行の高さと列の幅を変更してテーブルの高さと幅を変更する必要がある図形の特別なケースです。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}