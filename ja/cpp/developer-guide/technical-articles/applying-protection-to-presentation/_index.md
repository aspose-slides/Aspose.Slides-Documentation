---
title: プレゼンテーションへの保護の適用
type: docs
weight: 10
url: /ja/cpp/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Aspose.Slidesの一般的な使用法は、Microsoft PowerPoint 2007 (PPTX) プレゼンテーションを自動化されたワークフローの一部として作成、更新、保存することです。この方法でAspose.Slidesを使用するアプリケーションのユーザーは、出力プレゼンテーションにアクセスできます。それらを編集から保護することは一般的な懸念です。自動生成されたプレゼンテーションが元のフォーマットと内容を保持することが重要です。

この記事では、[プレゼンテーションとスライドの構成](/slides/ja/cpp/applying-protection-to-presentation/)およびAspose.Slides for C++が[保護を適用する方法](/slides/ja/cpp/applying-protection-to-presentation/)、次に[それを取り除く方法](/slides/ja/cpp/applying-protection-to-presentation/)について説明します。この機能はAspose.Slidesに特有のものであり、執筆時点ではMicrosoft PowerPointにはありません。これは、開発者に対してアプリケーションが作成するプレゼンテーションの使用方法を制御する手段を提供します。

{{% /alert %}} 
## **スライドの構成**
PPTXスライドは、自動形状、表、OLEオブジェクト、グループ化された形状、画像フレーム、ビデオフレーム、コネクタ、およびプレゼンテーションを構築するために使用できるさまざまな他の要素のような多くのコンポーネントで構成されています。

Aspose.Slides for C++では、スライド上の各要素はShapeオブジェクトに変換されます。言い換えれば、スライド上の各要素はShapeオブジェクトであるか、Shapeオブジェクトから派生したオブジェクトです。

PPTXの構造は複雑であるため、すべての種類の形状に一般的なロックを使用できるPPTとは異なり、異なる形状タイプに異なるロックのタイプがあります。BaseShapeLockクラスは一般的なPPTXロッククラスです。Aspose.Slides for C++でサポートされているPPTXのロックの種類は以下の通りです。

- AutoShapeLockは自動形状をロックします。
- ConnectorLockはコネクタ形状をロックします。
- GraphicalObjectLockはグラフィカルオブジェクトをロックします。
- GroupshapeLockはグループ形状をロックします。
- PictureFrameLockは画像フレームをロックします。

プレゼンテーションオブジェクト内のすべてのShapeオブジェクトに対して実行されるすべてのアクションは、プレゼンテーション全体に適用されます。
## **保護の適用と削除**
保護を適用することで、プレゼンテーションが編集できなくなります。これは、プレゼンテーションの内容を保護するための便利な技術です。
### **PPTX形状への保護の適用**
Aspose.Slides for C++は、スライド上の形状を処理するためのShapeクラスを提供します。

前述のように、各形状クラスには保護のための関連形状ロッククラスがあります。この記事では、NoSelect、NoMove、NoResizeロックに焦点を当てています。これらのロックは、形状を選択できない（マウスクリックや他の選択方法による）こと、また移動やサイズ変更できないことを保証します。

次に示すコードサンプルは、プレゼンテーション内のすべての形状タイプに保護を適用します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-ApplyProtection-ApplyProtection.cpp" >}}


### **保護の削除**
Aspose.Slides for C++を使用して適用された保護は、Aspose.Slides for C++でのみ削除できます。形状のロックを解除するには、適用されたロックの値をfalseに設定します。次に示すコードサンプルは、ロックされたプレゼンテーション内の形状をロック解除する方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-RemoveProtection-RemoveProtection.cpp" >}}
## **まとめ**
{{% alert color="primary" %}} 

Aspose.Slidesは、プレゼンテーション内の形状に保護を適用するためのいくつかのオプションを提供します。特定の形状をロックしたり、プレゼンテーション内のすべての形状をループしてすべてをロックして、実質的にプレゼンテーションをロックすることが可能です。

保護を解除することができるのは、以前に保護をかけたプレゼンテーションには、Aspose.Slides for C++だけです。ロックの値をfalseに設定することで保護を解除します。

{{% /alert %}} 
### **関連する記事**
- [ShapeEx](http://docs.aspose.com/display/slidesnet/ShapeEx+Class)クラス。
- [BaseShapeLockEx](http://docs.aspose.com/display/slidesnet/BaseShapeLockEx+Class)クラス。