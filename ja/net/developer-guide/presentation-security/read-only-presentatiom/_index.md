---
title: .NET で読み取り専用モードでプレゼンテーションを保存
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/net/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーションの保護
- 編集防止
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint ファイル（PPT、PPTX）を読み取り専用モードで読み込みおよび保存し、プレゼンテーションを変更せずに正確なスライドプレビューを提供します。"
---
## **概要**

PowerPoint 2019 で、Microsoft はプレゼンテーションを保護するために使用できるオプションの一つとして **Always Open Read-Only** 設定を導入しました。次の場合にこの読み取り専用設定を使用してプレゼンテーションを保護したいかもしれません。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたい場合。  
- 提供したプレゼンテーションが最終版であることを利用者に知らせたい場合。

**Always Open Read-Only** オプションをプレゼンテーションに選択すると、ユーザーがプレゼンテーションを開いたときに **Read-Only** 推奨が表示され、次のようなメッセージが表示されることがあります：*誤って変更しないように、作成者はこのファイルを読み取り専用で開くように設定しました。*

Read-Only 推奨は、ユーザーが編集できるようになる前にそれを解除する作業が必要になるため、編集を抑止するシンプルながら効果的な手段です。プレゼンテーションへの変更を防ぎ、丁寧にその旨を伝えたい場合は、Read-Only 推奨が適したオプションと言えるでしょう。

> **Read-Only** 保護が付いたプレゼンテーションを、最近導入された機能をサポートしていない古いバージョンの Microsoft PowerPoint で開くと、**Read-Only** 推奨は無視され（プレゼンテーションは通常通り開かれます）。

## **読み取り専用モードの適用**

Aspose.Slides for .NET を使用すると、プレゼンテーションを **Read-Only** に設定できます。これにより、ユーザーはプレゼンテーションを開いた後に **Read-Only** 推奨を確認できます。以下のサンプルコードは、Aspose.Slides を使用して C# でプレゼンテーションを **Read-Only** に設定する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Note**: **Read-Only** 推奨は、PowerPoint プレゼンテーションの編集を抑止したり、誤って変更されるのを防止することを目的としたものです。高度な知識を持つ人が編集しようと決めた場合、簡単に Read-Only 設定を解除できます。もし不正な編集を確実に防止したいのであれば、[暗号化とパスワードを使用したより厳格な保護](https://docs.aspose.com/slides/ja/net/password-protected-presentation/) を利用した方が適しています。 

{{% /alert %}} 

## **FAQ**

### 「Read-Only recommended」と完全なパスワード保護はどう違うのですか？

「Read-Only recommended」はファイルを読み取り専用モードで開くことを提案するだけで、簡単に回避できます。一方、[パスワード保護](/slides/ja/net/password-protected-presentation/) は実際に開封や編集を制限し、真正なセキュリティ制御が必要な場合に適しています。

### 「Read-Only recommended」を透かしと組み合わせて、さらに編集を抑止できますか？

はい。推奨は[透かし](/slides/ja/net/watermark/) と組み合わせて視覚的な抑止力とすることができます。これらは別々の仕組みですが、併用すると相乗効果があります。

### 推奨が有効な場合でも、マクロや外部ツールでファイルを変更できますか？

はい。推奨はプログラムによる変更をブロックしません。自動化された編集を防止したい場合は、[パスワードと暗号化](/slides/ja/net/password-protected-presentation/) を使用してください。

### 「Read-Only recommended」は「IsEncrypted」や「IsWriteProtected」フラグとどう関係していますか？

これらは異なるシグナルです。「Read-Only recommended」はソフトで任意のプロンプトです。一方、[IsWriteProtected](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager/iswriteprotected/) と [IsEncrypted](https://reference.aspose.com/slides/ja/net/aspose.slides/protectionmanager/isencrypted/) は、パスワードや暗号化に依存する実際の書き込みまたは読み取り制限を示します。