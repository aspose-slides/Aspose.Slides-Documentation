---
title: Android でプレゼンテーションを読み取り専用モードで保存
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
description: "Aspose.Slides for Android via Java を使用して PowerPoint ファイル（PPT、PPTX）を読み取り専用モードで保存し、プレゼンテーションを変更せずに正確なスライドプレビューを提供します。"
---
## **はじめに**

PowerPoint 2019 で、Microsoft はプレゼンテーションを保護するためにユーザーが使用できるオプションの一つとして **Always Open Read-Only** 設定を導入しました。この Read-Only 設定をプレゼンテーションの保護に使用したい場合は、次のようなときです。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたい場合。  
- 提供したプレゼンテーションが最終版であることを利用者に通知したい場合。  

プレゼンテーションに **Always Open Read-Only** オプションを設定した後、ユーザーがプレゼンテーションを開くと、**Read-Only** の推奨が表示され、次のようなメッセージが表示される場合があります。*誤って変更されるのを防ぐため、作成者はこのファイルを読み取り専用で開くように設定しました。*

Read-Only の推奨は、編集を抑止するシンプルながら効果的な手段です。ユーザーはプレゼンテーションを編集できるようになる前にこの推奨を解除する作業が必要になるためです。もしユーザーにプレゼンテーションの変更をさせたくなく、丁寧にその旨を伝えたい場合、Read-Only の推奨は適したオプションと言えるでしょう。

> **Read-Only** 保護が施されたプレゼンテーションが、最近導入された機能をサポートしていない古い Microsoft PowerPoint アプリケーションで開かれた場合、**Read-Only** の推奨は無視され（プレゼンテーションは通常どおり開かれます）。

## **Read-Only モードの適用**

Aspose.Slides for Android via Java を使用すると、プレゼンテーションを **Read-Only** に設定でき、ユーザーは（プレゼンテーションを開いた後に）**Read-Only** の推奨が表示されます。このサンプルコードは、Aspose.Slides を使用して Java でプレゼンテーションを **Read-Only** に設定する方法を示しています。

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Note**: **Read-Only** の推奨は、編集を抑止したり、PowerPoint プレゼンテーションの誤操作による変更を防止することを目的としています。やり方を熟知した動機のある人物がプレゼンテーションを編集しようとすれば、Read-Only 設定は簡単に解除できます。もし不正な編集を確実に防止したいのであれば、[暗号化とパスワードを伴うより厳格な保護](https://docs.aspose.com/slides/ja/androidjava/password-protected-presentation/) を使用した方が適切です。

{{% /alert %}} 

## **よくある質問**

### 「Read-Only recommended」は完全なパスワード保護とどう異なりますか？

「Read-Only recommended」はファイルを読み取り専用で開くように提案するだけで、簡単に回避できます。[パスワード保護](/slides/ja/androidjava/password-protected-presentation/) は実際に開くことや編集を制限し、実際のセキュリティ管理が必要な場合に適しています。

### 「Read-Only recommended」を透かしと組み合わせて編集をさらに抑止できますか？

はい。推奨は [透かし](/slides/ja/androidjava/watermark/) と組み合わせて視覚的な抑止策とすることができます。これらは別個の仕組みであり、相互に効果的に機能します。

### 推奨が有効な場合、マクロや外部ツールでファイルを変更できますか？

はい。推奨はプログラムによる変更をブロックしません。自動化された編集を防止するには、[パスワードと暗号化](/slides/ja/androidjava/password-protected-presentation/) を使用してください。

### 「Read-Only recommended」はメソッド「isEncrypted」および「isWriteProtected」とどう関係しますか？

これらは異なるシグナルです。「Read-Only recommended」は柔軟で任意のプロンプトです。一方、[isWriteProtected](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) と [isEncrypted](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) は、パスワードや暗号化に基づく実際の書き込みまたは読み取り制限を示します。