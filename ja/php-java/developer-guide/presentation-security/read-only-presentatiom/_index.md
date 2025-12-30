---
title: PHPで読み取り専用モードでプレゼンテーションを保存
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/php-java/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーション保護
- 編集防止
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して PowerPoint ファイル（PPT、PPTX）を読み取り専用モードで読み込み・保存し、プレゼンテーションを変更することなく正確なスライドプレビューを提供します。"
---

## **Read-Only モードの適用**

PowerPoint 2019 では、Microsoft はプレゼンテーションを保護するためのオプションの一つとして **Always Open Read-Only** 設定を導入しました。次のような場合に、この Read-Only 設定を使用してプレゼンテーションを保護したいと思うかもしれません。

- 誤って編集されることを防ぎ、プレゼンテーションの内容を安全に保ちたい場合。  
- 提供したプレゼンテーションが最終版であることを利用者に知らせたい場合。  

プレゼンテーションに **Always Open Read-Only** オプションを設定すると、ユーザーがそのプレゼンテーションを開いたときに **Read-Only** 推奨が表示され、次のようなメッセージが表示される場合があります: *誤って変更されるのを防ぐため、作成者はこのファイルを読み取り専用で開くように設定しています。*

**Read-Only** 推奨は、ユーザーが編集できるようになる前にそれを解除する作業が必要になるため、編集を抑止するシンプルながら効果的な手段です。プレゼンテーションの変更を防ぎ、かつ丁寧にその旨を伝えたい場合は、**Read-Only** 推奨が適したオプションになるでしょう。

> **Read-Only** 保護が設定されたプレゼンテーションを、最近導入された機能をサポートしていない古いバージョンの Microsoft PowerPoint で開くと、**Read-Only** 推奨は無視され（プレゼンテーションは通常通り開かれます）。

Aspose.Slides for PHP via Java を使用すると、プレゼンテーションを **Read-Only** に設定でき、ユーザーは（プレゼンテーションを開いた後に）**Read-Only** 推奨を見ることになります。このサンプルコードは、Aspose.Slides を使用してプレゼンテーションを **Read-Only** に設定する方法を示しています：
```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 
**Note**: **Read-Only** 推奨は、PowerPoint プレゼンテーションの誤った変更を防止または抑止することを目的とした単なる提案です。高度な知識を持つユーザーがプレゼンテーションを編集しようと決意した場合、Read-Only 設定は簡単に解除できます。もし不正な編集を確実に防ぎたいのであれば、[暗号化とパスワードを伴うより厳格な保護](https://docs.aspose.com/slides/php-java/password-protected-presentation/) を使用する方が適しています。
{{% /alert %}} 

## **FAQ**

**'Read-Only recommended' は完全なパスワード保護とどう違うのですか？**

'Read-Only recommended' はファイルを読み取り専用モードで開くよう提案するだけで、簡単に回避できます。[パスワード保護](/slides/ja/php-java/password-protected-presentation/) は実際に開封や編集を制限し、真のセキュリティ制御が必要な場合に適しています。

**'Read-Only recommended' と透かしを組み合わせて、編集をさらに抑止できますか？**

はい。推奨は [透かし](/slides/ja/php-java/watermark/) と組み合わせることができ、視覚的な抑止手段として機能します。両者は別個の仕組みであり、相互に補完します。

**推奨が有効な場合でも、マクロや外部ツールでファイルを変更できますか？**

はい。推奨はプログラムによる変更をブロックしません。自動化された編集を防止するには、[パスワードと暗号化](/slides/ja/php-java/password-protected-presentation/) を使用してください。

**'Read-Only recommended' は `isEncrypted` と `isWriteProtected` のメソッドとどう関係していますか？**

これらは異なるシグナルです。'Read-Only recommended' はソフトで任意のプロンプトであり、[isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/iswriteprotected/) と [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isencrypted/) はパスワードや暗号化に依存した実際の書き込み・読み取り制限を示します。