---
title: Aspose.Slidesにおけるフォント置換のための警告コールバックの取得
type: docs
weight: 90
url: /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides for Javaは、レンダリングプロセス中に使用されるフォントがマシンに存在しない場合に、フォント置換のための警告コールバックを取得することを可能にします。警告コールバックは、レンダリングプロセス中に発生するフォントの欠損やアクセス不可能な問題をデバッグするのに役立ちます。

{{% /alert %}} 

Aspose.Slides for Javaは、レンダリングプロセス中に警告コールバックを受け取るためのシンプルなAPIメソッドを提供します。以下の手順に従って警告コールバックを設定してください。

1. コールバックを受け取るためのカスタムコールバッククラスを作成します。
1. LoadOptionsクラスを使用して警告コールバックを設定します。
1. ターゲットマシンで使用できないフォントを含むプレゼンテーションファイルをロードします。
1. スライドのサムネイルを生成してその効果を確認します。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}