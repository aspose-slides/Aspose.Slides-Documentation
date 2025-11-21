---
title: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/net/read-only-presentation/
keywords: "読み取り専用設定, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET の読み取り専用 PowerPoint プレゼンテーション"
---

## **読み取り専用モードを適用**

PowerPoint 2019 で Microsoft は、プレゼンテーションを保護するためにユーザーが使用できるオプションの一つとして **Always Open Read-Only** 設定を導入しました。次のような場合にこの読み取り専用設定を使用してプレゼンテーションを保護したいことがあります。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたい場合。  
- 提供したプレゼンテーションが最終版であることを利用者に知らせたい場合。

プレゼンテーションに **Always Open Read-Only** オプションを選択すると、ユーザーがプレゼンテーションを開いたときに **Read-Only** 推奨が表示され、次のようなメッセージが表示されることがあります。*To prevent accidental changes, the author has set this file to open as read-only.*

**Read-Only** 推奨は、ユーザーが編集できるようになる前にこの設定を解除する作業が必要になるため、編集を抑止するシンプルかつ効果的な手段です。プレゼンテーションへの変更を防ぎ、かつ丁寧にその旨を伝えたい場合、**Read-Only** 推奨は適したオプションとなります。

> **Read-Only** 保護付きのプレゼンテーションが、最近導入された機能をサポートしていない古い Microsoft PowerPoint アプリケーションで開かれた場合、**Read-Only** 推奨は無視され（プレゼンテーションは通常通り開かれます）。

Aspose.Slides for .NET を使用すると、プレゼンテーションを **Read-Only** に設定できます。これにより、ユーザーは（プレゼンテーションを開いた後）**Read-Only** 推奨を見ることになります。以下のサンプルコードは、Aspose.Slides を使用して C# でプレゼンテーションを **Read-Only** に設定する方法を示しています。
```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}} 
**Note**: **Read-Only** 推奨は、PowerPoint プレゼンテーションの誤編集を防止または抑止することを目的としたものです。動機のある熟練者がプレゼンテーションを編集しようとした場合、**Read-Only** 設定は簡単に解除できます。権限のない編集を確実に防止したい場合は、[暗号化とパスワードを含むより厳格な保護](https://docs.aspose.com/slides/net/password-protected-presentation/) を利用する方が適しています。 
{{% /alert %}} 

## **FAQ**

**「Read-Only recommended」と完全なパスワード保護はどう違いますか？**

「Read-Only recommended」はファイルを読み取り専用モードで開くことを提案するだけで、容易に回避できます。[パスワード保護](/slides/ja/net/password-protected-presentation/) は実際に開封や編集を制限し、真のセキュリティ制御が必要な場合に適しています。

**「Read-Only recommended」を透かしと組み合わせて編集をさらに抑止できますか？**

はい。推奨は[透かし](/slides/ja/net/watermark/) と組み合わせて視覚的な抑止力として機能します。両者は別個の仕組みであり、併用すると効果的です。

**推奨が有効な状態でも、マクロや外部ツールがファイルを変更できますか？**

はい。推奨はプログラムによる変更をブロックしません。自動化された編集を防止したい場合は、[パスワードと暗号化](/slides/ja/net/password-protected-presentation/) を使用してください。

**「Read-Only recommended」は「IsEncrypted」や「IsWriteProtected」フラグとどう関係していますか？**

これらは別のシグナルです。「Read-Only recommended」はソフトで任意のプロンプトであり、[IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/iswriteprotected/) と[IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/isencrypted/) はパスワードや暗号化に依存した実際の書き込み・読み取り制限を示します。