---
title: C++ を使用した読み取り専用モードでのプレゼンテーション保存
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/cpp/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーションの保護
- 編集の防止
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint ファイル（PPT、PPTX）を読み取り専用モードでロードおよび保存し、プレゼンテーションを変更せずに正確なスライドプレビューを提供します。"
---

## **読み取り専用モードの適用**

PowerPoint 2019 で、Microsoft はプレゼンテーションを保護するためのオプションの一つとして **Always Open Read-Only** 設定を導入しました。次の場合に、この読み取り専用設定を使用してプレゼンテーションを保護したいかもしれません。

- 誤って編集されるのを防ぎ、プレゼンテーションの内容を安全に保ちたいとき。
- 提供したプレゼンテーションが最終版であることを相手に知らせたいとき。

プレゼンテーションに **Always Open Read-Only** オプションを設定すると、ユーザーがそのプレゼンテーションを開いたときに **Read-Only** 推奨が表示され、次のようなメッセージが表示される場合があります: *意図しない変更を防止するため、作成者がこのファイルを読み取り専用で開くように設定しました。*

**Read-Only** 推奨は、編集を阻止するシンプルながら効果的な抑止策です。ユーザーはプレゼンテーションを編集できるようになる前にこの推奨を解除する作業が必要になるため、編集を思いとどまらせます。プレゼンテーションへの変更を防ぎ、かつ丁寧にその旨を伝えたい場合、**Read-Only** 推奨は適したオプションと言えるでしょう。

> **Read-Only** 保護が設定されたプレゼンテーションを、最近導入された機能をサポートしていない古い Microsoft PowerPoint アプリケーションで開くと、**Read-Only** 推奨は無視され（プレゼンテーションは通常どおり開かれます）。

Aspose.Slides for C++ を使用すると、プレゼンテーションを **Read-Only** に設定できます。これにより、ユーザーは（プレゼンテーションを開いた後に）**Read-Only** 推奨を見ることになります。このサンプルコードは、Aspose.Slides を使用して C++ でプレゼンテーションを **Read-Only** に設定する方法を示しています。
``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" %}} 

**注意**: **Read-Only** 推奨は、PowerPoint プレゼンテーションの編集を抑止したり、誤って変更されるのを防止することだけを目的としています。動機のある人が（自分が何をしているか理解している場合）プレゼンテーションを編集しようとすれば、**Read-Only** 設定は簡単に解除できます。もし不正な編集を確実に防止したい場合は、[より厳格な暗号化やパスワードを伴う保護](https://docs.aspose.com/slides/cpp/password-protected-presentation/) を使用した方がよいでしょう。

{{% /alert %}} 

## **FAQ**

**'Read-Only recommended' は完全なパスワード保護とどう違うのですか？**

'Read-Only recommended' は、ファイルを読み取り専用モードで開くよう提案を表示するだけで、簡単に回避できます。[Password protection](/slides/ja/cpp/password-protected-presentation/) は実際に開封や編集を制限し、実際のセキュリティ管理が必要なときに適しています。

**'Read-Only recommended' を透かしと組み合わせて編集をさらに抑止できますか？**

はい。**Read-Only** 推奨は、[watermarks](/slides/ja/cpp/watermark/) と組み合わせて視覚的な抑止策とすることができ、これらは別々の仕組みですがうまく連携します。

**推奨が有効な状態でも、マクロや外部ツールがファイルを変更できますか？**

はい。**Read-Only** 推奨はプログラムによる変更をブロックしません。自動編集を防止するには、[passwords and encryption](/slides/ja/cpp/password-protected-presentation/) を使用してください。

**'Read-Only recommended' は 'is encrypted' や 'is write protected' フラグとどのような関係がありますか？**

これらは異なるシグナルです。**Read-Only recommended** はソフトで任意のプロンプトであり、[get_IsWriteProtected](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) と [get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_isencrypted/) は、パスワードや暗号化に依存する実際の書き込み・読み取り制限を示します。