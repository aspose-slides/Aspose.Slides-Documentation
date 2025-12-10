---
title: Java を使用して読み取り専用モードでプレゼンテーションを保存する
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/java/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーションの保護
- 編集の防止
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint ファイル（PPT、PPTX）を読み取り専用モードで読み込み・保存し、プレゼンテーションを変更せずに正確なスライドプレビューを提供します。"
---

## **読み取り専用モードの適用**

PowerPoint 2019 で、Microsoft はプレゼンテーションを保護するためのオプションのひとつとして **Always Open Read-Only** 設定を導入しました。次の場合にこの読み取り専用設定を使用してプレゼンテーションを保護したいかもしれません。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたい場合。  
- 提供したプレゼンテーションが最終版であることを利用者に知らせたい場合。

プレゼンテーションに **Always Open Read-Only** オプションを設定すると、ユーザーがプレゼンテーションを開いたときに **Read-Only** の推奨が表示され、次のようなメッセージが表示される場合があります：*誤って変更されるのを防ぐため、作成者はこのファイルを読み取り専用で開くように設定しています。*

Read-Only 推奨はシンプルで効果的な抑止策であり、ユーザーは編集できるようになる前にそれを解除する作業が必要です。もしプレゼンテーションへの変更を防ぎ、礼儀正しくそれを伝えたい場合、Read-Only 推奨は適したオプションとなります。

> **Read-Only** 保護が設定されたプレゼンテーションが、最近導入された機能をサポートしていない古いバージョンの Microsoft PowerPoint で開かれた場合、**Read-Only** 推奨は無視され（プレゼンテーションは通常どおり開かれます）。

Aspose.Slides for Java を使用すると、プレゼンテーションを **Read-Only** に設定でき、ユーザーは（プレゼンテーションを開いた後）**Read-Only** の推奨を確認できます。このサンプルコードは、Aspose.Slides を使用して Java でプレゼンテーションを **Read-Only** に設定する方法を示しています。
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

**注**: **Read-Only** 推奨は、PowerPoint プレゼンテーションの編集を抑止したり、誤って変更されるのを防ぐことを目的としたものです。もし意図的に（自分で何をしているか分かっている）人物がプレゼンテーションを編集しようとすれば、簡単に Read-Only 設定を解除できます。権限のない編集を本当に防ぐ必要がある場合は、[more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/java/password-protected-presentation/) を使用した方がよいでしょう。

{{% /alert %}} 

## **FAQ**

**'Read-Only recommended' はフル パスワード保護とどう違うのですか？**

'Read-Only recommended' はファイルを読み取り専用モードで開くよう提案するだけで、簡単に回避できます。[Password protection](/slides/ja/java/password-protected-presentation/) は実際に開封や編集を制限し、真のセキュリティ管理が必要なときに適しています。

**'Read-Only recommended' を透かしと組み合わせて編集をさらに抑止できますか？**

はい。推奨は [watermarks](/slides/ja/java/watermark/) と組み合わせて視覚的な抑止効果を高められます。これらは別々の仕組みであり、併用すると相乗効果があります。

**マクロや外部ツールは推奨が有効なときでもファイルを変更できますか？**

はい。推奨はプログラムによる変更をブロックしません。自動化された編集を防ぎたい場合は、[passwords and encryption](/slides/ja/java/password-protected-presentation/) を使用してください。

**'Read-Only recommended' はメソッド 'isEncrypted' と 'isWriteProtected' とどう関係していますか？**

これらは別のシグナルです。'Read-Only recommended' はソフトで任意のプロンプトであり、[isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isWriteProtected--) と [isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isEncrypted--) はパスワードや暗号化に基づく実際の書き込みまたは読み取り制限を示します。