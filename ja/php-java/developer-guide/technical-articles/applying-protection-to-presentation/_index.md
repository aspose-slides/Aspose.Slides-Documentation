---
title: プレゼンテーションに保護を適用する
type: docs
weight: 60
url: /ja/php-java/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Aspose.Slidesの一般的な使用法は、Microsoft PowerPoint 2007 (PPTX) のプレゼンテーションを自動化ワークフローの一部として作成、更新、保存することです。このようにAspose.Slidesを利用するアプリケーションのユーザーは、出力されたプレゼンテーションにアクセスできます。それらを編集から保護することは一般的な懸念事項です。自動生成されたプレゼンテーションが元の書式とコンテンツを保持することが重要です。

この記事では、[プレゼンテーションとスライドがどのように構成されているか](/slides/ja/php-java/applying-protection-to-presentation/)と、Aspose.Slides for PHP via Javaがどのように[保護を適用するか](/slides/ja/php-java/applying-protection-to-presentation/)、そして[それを削除するか](/slides/ja/php-java/applying-protection-to-presentation/)を説明します。この機能はAspose.Slides特有のもので、執筆時点ではMicrosoft PowerPointにはありません。これにより、開発者はアプリケーションが作成するプレゼンテーションの使用方法を制御できるようになります。

{{% /alert %}} 
## **スライドの構成**
PPTXスライドは、オートシェイプ、テーブル、OLEオブジェクト、グループ化されたシェイプ、図枠、ビデオフレーム、コネクタなど、プレゼンテーションを構成するさまざまな要素から成り立っています。Aspose.Slides for PHP via Javaでは、スライド上の各要素はShapeオブジェクトに変換されます。言い換えれば、スライド上の各要素はShapeオブジェクトまたはShapeオブジェクトから派生したオブジェクトです。PPTXの構造は複雑で、すべてのタイプのシェイプに対して一般的なロックを使用できるPPTとは異なり、異なるシェイプタイプごとに異なるタイプのロックがあります。BaseShapeLockクラスは、一般的なPPTXロッククラスです。Aspose.Slides for PHP via Javaは、PPTX用に以下のロックタイプをサポートしています。

- AutoShapeLockはオートシェイプをロックします。
- ConnectorLockはコネクタシェイプをロックします。
- GraphicalObjectLockはグラフィカルオブジェクトをロックします。
- GroupshapeLockはグループシェイプをロックします。
- PictureFrameLockは図枠をロックします。
  プレゼンテーションオブジェクト内のすべてのShapeオブジェクトに対して実行されたアクションは、プレゼンテーション全体に適用されます。
## **保護の適用と削除**
保護を適用すると、プレゼンテーションが編集できないようになります。これは、プレゼンテーションのコンテンツを保護するための便利な手法です。
## **PPTXシェイプへの保護を適用する**
Aspose.Slides for PHP via Javaは、スライド上のシェイプを処理するためのShapeクラスを提供します。

前述のように、各シェイプクラスには保護のための関連するシェイプロッククラスがあります。この記事では、NoSelect、NoMoveおよびNoResizeロックに焦点を当てます。これらのロックは、シェイプが選択できない（マウスクリックや他の選択方法を通じて）こと、また、移動やサイズ変更できないことを保証します。

以下のコードサンプルでは、プレゼンテーション内のすべてのシェイプタイプに保護を適用します。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-ApplyProtection-ApplyProtection.java" >}}
## **保護の削除**
Aspose.Slides for .NET/Javaを使用して適用された保護は、Aspose.Slides for .NET/Javaでのみ削除できます。シェイプのロックを解除するには、適用されたロックの値をfalseに設定します。以下のコードサンプルは、ロックされたプレゼンテーション内のシェイプのロックを解除する方法を示しています。

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemoveProtection-RemoveProtection.java" >}}




## **まとめ**
{{% alert color="primary" %}} 

Aspose.Slidesは、プレゼンテーション内のシェイプに保護を適用するための多くのオプションを提供します。特定のシェイプをロックすることも、プレゼンテーション内のすべてのシェイプをループしてロックし、実質的にプレゼンテーションをロックすることも可能です。保護されたプレゼンテーションからのみ、Aspose.Slides for PHP via Javaが保護を解除できます。ロックの値をfalseに設定することで保護を削除します。

{{% /alert %}}