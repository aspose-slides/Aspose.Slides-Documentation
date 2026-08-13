---
title: Javaで読み取り専用モードでプレゼンテーションを保存する
linktitle: 読み取り専用プレゼンテーション
type: docs
weight: 30
url: /ja/java/read-only-presentation/
keywords:
- 読み取り専用
- プレゼンテーションの保護
- 編集防止
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint ファイル（PPT、PPTX）を読み取り専用モードで読み込みおよび保存し、プレゼンテーションを変更せずに正確なスライドプレビューを提供します。"
---
## **はじめに**

PowerPoint 2019 では、Microsoft がプレゼンテーションを保護するためにユーザーが使用できるオプションの一つとして **Always Open Read-Only** 設定を導入しました。次のような場合に、この読み取り専用設定を使用してプレゼンテーションを保護したいと考えるかもしれません。

- 誤って編集されることを防ぎ、プレゼンテーションの内容を安全に保ちたい。  
- 提供したプレゼンテーションが最終版であることを利用者に伝えたい。  

プレゼンテーションに **Always Open Read-Only** オプションを設定すると、ユーザーがそのプレゼンテーションを開いたときに **Read-Only** の推奨が表示され、次のようなメッセージが表示される場合があります: *誤って変更されるのを防ぐため、作成者はこのファイルを読み取り専用で開くように設定しました。*

Read-Only の推奨は、ユーザーが編集を許可される前にそれを解除する作業が必要になるため、編集を思いとどまらせるシンプルながら効果的な抑止手段です。プレゼンテーションへの変更を防ぎ、かつ丁寧にその旨を伝えたい場合、Read-Only の推奨は適したオプションと言えるでしょう。

> **Read-Only** 保護が設定されたプレゼンテーションが、最近導入された機能をサポートしていない古いバージョンの Microsoft PowerPoint で開かれた場合、**Read-Only** の推奨は無視され（プレゼンテーションは通常通り開かれます）。

## **読み取り専用モードの適用**

Aspose.Slides for Java を使用すると、プレゼンテーションを **Read-Only** に設定でき、ユーザーは（プレゼンテーションを開いた後） **Read-Only** の推奨が表示されます。このサンプルコードは、Aspose.Slides を用いて Java でプレゼンテーションを **Read-Only** に設定する方法を示しています。

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

**注**: **Read-Only** の推奨は、PowerPoint プレゼンテーションの誤った編集や偶発的な変更を防止することを目的としたものです。もし、何をすべきか熟知した意欲的なユーザーがプレゼンテーションを編集しようとすれば、Read-Only 設定は簡単に解除できます。実際に不正な編集を防止したい場合は、[暗号化やパスワードを伴う、より厳格な保護](https://docs.aspose.com/slides/ja/java/password-protected-presentation/) を使用した方が適切です。 

{{% /alert %}} 

## **よくある質問**

### 'Read-Only recommended' は完全なパスワード保護とどう違うのですか？

'Read-Only recommended' はファイルを読み取り専用モードで開くことを提案するだけで、簡単に回避できます。[パスワード保護](/slides/ja/java/password-protected-presentation/) は実際に開封や編集を制限し、実際のセキュリティ制御が必要な場合に適しています。

### 'Read-Only recommended' をウォーターマークと組み合わせて、編集をさらに抑止できますか？

はい。推奨は [ウォーターマーク](/slides/ja/java/watermark/) と組み合わせて視覚的な抑止策とすることができ、これらは別々の機構でありながらうまく連携します。

### 推奨が有効になっている場合でも、マクロや外部ツールがファイルを変更できますか？

はい。推奨はプログラムによる変更をブロックしません。自動的な編集を防止するには、[パスワードと暗号化](/slides/ja/java/password-protected-presentation/) を使用してください。

### 'Read-Only recommended' はメソッド 'isEncrypted' と 'isWriteProtected' とどのような関係がありますか？

これらは異なるシグナルです。'Read-Only recommended' はソフトで任意のプロンプトにすぎません。[isWriteProtected](https://reference.aspose.com/slides/ja/java/com.aspose.slides/protectionmanager/#isWriteProtected--) と [isEncrypted](https://reference.aspose.com/slides/ja/java/com.aspose.slides/protectionmanager/#isEncrypted--) は、パスワードや暗号化に基づく実際の書き込みまたは読み取り制限を示します。