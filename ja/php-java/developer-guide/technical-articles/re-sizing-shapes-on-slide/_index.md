---
title: スライド上の図形のサイズ変更
type: docs
weight: 110
url: /ja/php-java/re-sizing-shapes-on-slide/
---

## **スライド上の図形のサイズ変更**
Aspose.Slides for PHP via Java の顧客からよく寄せられる質問の一つは、スライドのサイズが変更されたときにデータが切断されないように、図形のサイズを変更する方法です。この短い技術的ヒントでは、その達成方法を示します。

図形の方向性を保つために、スライド上の各図形は新しいスライドサイズに応じて更新する必要があります。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeShape-ResizeShape.java" >}}

{{% alert color="primary" %}} 

スライドにテーブルがある場合、上記のコードは完全には機能しません。その場合、テーブルの各セルをサイズ変更する必要があります。

{{% /alert %}} 

テーブルを含むスライドのサイズを変更する必要がある場合、以下のコードを使用する必要があります。テーブルの幅や高さを設定することは、テーブルの高さと幅を変更するために、個々の行の高さや列の幅を変更する必要がある特別なケースです。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeSlideWithTable-ResizeSlideWithTable.java" >}}