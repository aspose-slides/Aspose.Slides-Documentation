---
title: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/nodejs-java/read-only-presentation/
---

## **Read-Only モードの適用**

PowerPoint 2019 で、Microsoft はプレゼンテーションを保護するために使用できるオプションの一つとして **Always Open Read-Only** 設定を導入しました。次の場合に、この Read-Only 設定を使用してプレゼンテーションを保護したいと思うかもしれません。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたいとき。  
- 提供したプレゼンテーションが最終版であることを利用者に知らせたいとき。

プレゼンテーションに **Always Open Read-Only** オプションを選択すると、ユーザーがそのプレゼンテーションを開いたときに **Read-Only** 推奨が表示され、次のようなメッセージが表示されることがあります。*「誤って変更しないように、作成者がこのファイルを読み取り専用で開くように設定しています。」*

Read-Only 推奨は、ユーザーが編集できるようになる前にそれを解除する作業が必要になるため、編集を抑止するシンプルながら効果的な阻止策です。プレゼンテーションの変更を防ぎつつ、丁寧にその旨を伝えたい場合、Read-Only 推奨は有力な選択肢となります。

> **Read-Only** 保護が付いたプレゼンテーションが、最近導入された機能に対応していない古い Microsoft PowerPoint アプリケーションで開かれた場合、**Read-Only** 推奨は無視され（プレゼンテーションは通常通り開かれ）ます。

Aspose.Slides for Node.js via Java を使用すると、プレゼンテーションを **Read-Only** に設定できます。これにより、ユーザーは（プレゼンテーションを開いた後）**Read-Only** 推奨を見ることになります。以下のサンプルコードは、JavaScript（Node.js via Java）で Aspose.Slides を使用してプレゼンテーションを **Read-Only** に設定する方法を示しています。
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

**注**: **Read-Only** 推奨は、PowerPoint プレゼンテーションの誤編集を防止または抑止することを目的としたものです。技術的に熟練したユーザーが意図的に編集しようとした場合、簡単に Read-Only 設定を解除できます。実際に不正な編集を防止したい場合は、[暗号化とパスワードを伴うより厳格な保護](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/) を使用する方が適しています。

{{% /alert %}} 

## **FAQ**

**「Read-Only 推奨」と完全なパスワード保護はどのように違うのですか？**

「Read-Only 推奨」はファイルを読み取り専用モードで開くように促すだけで、容易に回避できます。一方、[パスワード保護](/slides/ja/nodejs-java/password-protected-presentation/) は開封や編集自体を制限し、真のセキュリティ制御が必要なときに適しています。

**「Read-Only 推奨」は透かしと組み合わせて更に編集を抑止できますか？**

はい。推奨は [透かし](/slides/ja/nodejs-java/watermark/) と組み合わせて視覚的な抑止力として機能します。両者は別々の仕組みですが、併用すると効果的です。

**推奨が有効な状態でも、マクロや外部ツールでファイルを変更できますか？**

はい。推奨はプログラムによる変更をブロックしません。自動化された編集を防止したい場合は、[パスワードと暗号化](/slides/ja/nodejs-java/password-protected-presentation/) を使用してください。

**「Read-Only 推奨」はフラグ「IsEncrypted」や「IsWriteProtected」とどう関係していますか？**

これらは別のシグナルです。「Read-Only 推奨」はソフトなオプションの通知であり、[isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) や [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/isencrypted/) はパスワードや暗号化に基づく実際の書き込みまたは読み取り制限を示します。