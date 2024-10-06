---
title: Aspose.Slidesにおけるフォント置換のための警告コールバックの取得
type: docs
weight: 90
url: /ja/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Javaは、レンダリングプロセス中に使用されているフォントがマシン上で利用可能でない場合に、フォント置換のための警告コールバックを受け取ることを可能にします。警告コールバックは、レンダリングプロセス中に欠落またはアクセス不可のフォントの問題をデバッグするのに役立ちます。



{{% /alert %}} 

Aspose.Slides for PHP via Javaは、レンダリングプロセス中に警告コールバックを受け取るためのシンプルなAPIメソッドを提供します。以下の手順に従って、警告コールバックを設定してください。

1. コールバックを受信するためのカスタムコールバッククラスを作成します。
1. LoadOptionsクラスを使用して警告コールバックを設定します。
1. ターゲットマシン上で利用できないフォントを使用しているプレゼンテーションファイルを読み込みます。
1. スライドのサムネイルを生成して、効果を確認します。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}