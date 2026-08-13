---
title: C++ を使用した読み取り専用モードでプレゼンテーションを保存
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/cpp/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーションを保護
- 編集を防止
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint ファイル（PPT、PPTX）を読み取り専用モードでロードおよび保存し、プレゼンテーションを変更せずに正確なスライドプレビューを提供します。"
---
## **イントロダクション**

PowerPoint 2019 で、Microsoft はプレゼンテーションを保護するオプションの一つとして **Always Open Read-Only** 設定を導入しました。次のような場合にこの読み取り専用設定を使用したい場合があります。

- 誤って編集されることを防ぎ、プレゼンテーションの内容を安全に保ちたいとき。  
- 提供したプレゼンテーションが最終版であることを利用者に知らせたいとき。

プレゼンテーションに **Always Open Read-Only** オプションを選択すると、利用者がプレゼンテーションを開いた際に **Read-Only** の推奨が表示され、次のようなメッセージが表示されることがあります。*誤って変更されるのを防ぐため、作成者がこのファイルを読み取り専用で開くように設定しました。*

Read-Only の推奨は、編集を阻止するためのシンプルながら効果的な抑止策です。利用者は編集可能にする前にこの推奨を解除する作業が必要になるため、編集を控えるようになります。利用者に丁寧に変更不可であることを伝えたい場合、Read-Only の推奨は適切なオプションとなります。

> **Read-Only** 保護が付いたプレゼンテーションが、最近導入された機能をサポートしていない古い Microsoft PowerPoint アプリケーションで開かれた場合、**Read-Only** の推奨は無視され、プレゼンテーションは通常通りに開かれます。

## **Read-Only モードの適用**

Aspose.Slides for C++ を使用すると、プレゼンテーションを **Read-Only** に設定できます。これにより、利用者はプレゼンテーションを開いたときに **Read-Only** の推奨が表示されます。以下のサンプルコードは、Aspose.Slides を使用して C++ でプレゼンテーションを **Read-Only** に設定する方法を示しています。

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**注**: **Read-Only** の推奨は、PowerPoint プレゼンテーションの誤操作による編集を抑止することを目的としたものです。作業手順を熟知したユーザーが意図的に編集する場合、簡単に Read-Only 設定を解除できます。未承認の編集を確実に防止したい場合は、[暗号化とパスワードを伴うより厳格な保護](https://docs.aspose.com/slides/ja/cpp/password-protected-presentation/) の使用をお勧めします。 

{{% /alert %}} 

## **FAQ**

### 「Read-Only recommended」と完全なパスワード保護はどう違いますか？

「Read-Only recommended」はファイルを読み取り専用モードで開くことを提案するだけで、回避が容易です。[パスワード保護](/slides/ja/cpp/password-protected-presentation/) は実際に開封や編集を制限し、実質的なセキュリティが必要なときに適しています。

### 「Read-Only recommended」をウォーターマークと組み合わせてさらに編集を抑止できますか？

はい。推奨は[ウォーターマーク](/slides/ja/cpp/watermark/) と組み合わせて視覚的な抑止策として機能します。両者は別個の仕組みですが、併用すると効果的です。

### 推奨が有効な状態でもマクロや外部ツールでファイルを変更できますか？

はい。推奨はプログラムによる変更をブロックしません。自動化された編集を防止するには、[パスワードと暗号化](/slides/ja/cpp/password-protected-presentation/) を使用してください。

### 「Read-Only recommended」は「is encrypted」や「is write protected」フラグとどう関係しますか？

これらは異なるシグナルです。「Read-Only recommended」はソフトなオプションの提示にすぎませんが、[get_IsWriteProtected](https://reference.aspose.com/slides/ja/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) と [get_IsEncrypted](https://reference.aspose.com/slides/ja/cpp/aspose.slides/protectionmanager/get_isencrypted/) はパスワードや暗号化に基づく実際の書き込み・読み取り制限を示します。