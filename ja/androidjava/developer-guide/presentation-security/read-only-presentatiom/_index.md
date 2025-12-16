---
title: Androidでプレゼンテーションを読み取り専用モードで保存
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/androidjava/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーションの保護
- 編集防止
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint ファイル (PPT、PPTX) を読み取り専用モードで保存し、プレゼンテーションを変更せずに正確なスライドプレビューを提供します。"
---

## **読み取り専用モードの適用**

PowerPoint 2019 では、Microsoft がプレゼンテーションを保護するためにユーザーが使用できるオプションの一つとして **Always Open Read-Only** 設定を導入しました。この読み取り専用設定を使用してプレゼンテーションを保護したい場合は、以下のような時です。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたい場合。  
- 提供したプレゼンテーションが最終版であることを利用者に知らせたい場合。  

プレゼンテーションに **Always Open Read-Only** オプションを設定すると、ユーザーがそのプレゼンテーションを開いたときに **Read-Only** の推奨が表示され、次のようなメッセージが表示されることがあります。*誤って変更されるのを防ぐため、作成者がこのファイルを読み取り専用で開くように設定しました。*

Read-Only の推奨は、ユーザーがプレゼンテーションを編集できるようになる前にそれを解除する作業が必要となるため、編集を抑止するシンプルかつ効果的な手段です。プレゼンテーションへの変更を許可したくなく、かつ丁寧にその旨を伝えたい場合は、Read-Only の推奨が適したオプションとなります。

> **Read-Only** 保護が施されたプレゼンテーションが、最近導入された機能に対応していない古いバージョンの Microsoft PowerPoint で開かれた場合、**Read-Only** の推奨は無視され（プレゼンテーションは通常どおり開かれます）。

Aspose.Slides for Android via Java を使用すると、プレゼンテーションを **Read-Only** に設定できます。これにより、ユーザーは（プレゼンテーションを開いた後）**Read-Only** の推奨が表示されます。以下のサンプルコードは、Aspose.Slides を使用して Java でプレゼンテーションを **Read-Only** に設定する方法を示しています。
```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

**Note**: **Read-Only** の推奨は、PowerPoint プレゼンテーションの編集を防止したり、誤って変更されるのを防ぐためのシンプルな手段です。動機があり、手順を理解している人がプレゼンテーションを編集しようとした場合、Read-Only 設定は簡単に解除できます。もし不正な編集を確実に防止したいのであれば、[暗号化とパスワードを使用したより厳格な保護](https://docs.aspose.com/slides/androidjava/password-protected-presentation/) を使用した方が適しています。

{{% /alert %}} 

## **よくある質問**

**'Read-Only recommended' は完全なパスワード保護とどう違うのですか？**

`Read-Only recommended` は、ファイルを読み取り専用モードで開くことを提案するだけで、簡単にバイパスできます。[パスワード保護](/slides/ja/androidjava/password-protected-presentation/) は実際に開くことや編集することを制限し、真のセキュリティ制御が必要な場合に適しています。

**`Read-Only recommended` は透かしと組み合わせて編集をさらに抑止できますか？**

はい。推奨は [透かし](/slides/ja/androidjava/watermark/) と組み合わせることができ、視覚的な抑止手段として機能します。これらは別個の仕組みであり、併用すると効果的です。

**推奨が有効な状態でも、マクロや外部ツールがファイルを変更できるでしょうか？**

はい。推奨はプログラムによる変更をブロックしません。自動化された編集を防止するには、[パスワードと暗号化](/slides/ja/androidjava/password-protected-presentation/) を使用してください。

**`Read-Only recommended` はメソッド 'isEncrypted' と 'isWriteProtected' とどのように関係していますか？**

これらは異なるシグナルです。`Read-Only recommended` はソフトで任意のプロンプトです。一方、[isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) と [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) は、パスワードや暗号化に依存した実際の書き込みまたは読み取りの制限を示します。