---
title: .NET でプレゼンテーションの SmartArt シェイプ ノードを管理する
linktitle: SmartArt シェイプ ノード
type: docs
weight: 30
url: /ja/net/manage-smartart-shape-node/
keywords:
- SmartArt ノード
- 子ノード
- ノードの追加
- ノードの位置
- ノードへのアクセス
- ノードの削除
- カスタム位置
- アシスタントノード
- 塗りつぶし形式
- ノードのレンダリング
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PPT および PPTX の SmartArt シェイプ ノードを管理します。プレゼンテーションを効率化するための明確なコードサンプルとヒントが得られます。"
---

## **SmartArt ノードを追加**
Aspose.Slides for .NET は、SmartArt シェイプを最も簡単に管理できる API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードと子ノードを追加する方法を示しています。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
- SmartArt シェイプの NodeCollection に新しいノードを追加し、TextFrame にテキストを設定します。
- 次に、追加した SmartArt ノードに子ノードを追加し、TextFrame にテキストを設定します。
- プレゼンテーションを保存します。
```c#
// 必要なプレゼンテーションを読み込む
Presentation pres = new Presentation("AddNodes.pptx");

// 最初のスライド内のすべてのシェイプを走査
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // シェイプが SmartArt タイプか確認
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // シェイプを SmartArt に型変換
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // 新しい SmartArt ノードを追加
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // テキストを追加
        TemNode.TextFrame.Text = "Test";

        // 親ノードに新しい子ノードを追加します。コレクションの末尾に追加されます
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // テキストを追加
        newNode.TextFrame.Text = "New Node Added";

    }
}

// プレゼンテーションを保存
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **特定の位置に SmartArt ノードを追加**
以下のサンプルコードでは、SmartArt シェイプの各ノードに属する子ノードを特定の位置に追加する方法を説明します。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用して最初のスライドの参照を取得します。
- アクセスしたスライドに StackedList タイプの SmartArt シェイプを追加します。
- 追加した SmartArt シェイプの最初のノードにアクセスします。
- 位置 2 に子ノードを追加し、テキストを設定します。
- プレゼンテーションを保存します。
```c#
// プレゼンテーション インスタンスを作成
Presentation pres = new Presentation();

// プレゼンテーション スライドにアクセス
ISlide slide = pres.Slides[0];

// SmartArt IShape を追加
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// インデックス 0 の SmartArt ノードにアクセス
ISmartArtNode node = smart.AllNodes[0];

// 親ノードの位置 2 に新しい子ノードを追加
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// テキストを追加
chNode.TextFrame.Text = "Sample Text Added";

// プレゼンテーションを保存
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **SmartArt ノードにアクセス**
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプを追加したときにのみ設定されるため、変更できないことに注意してください。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
- SmartArt シェイプ内のすべてのノードを走査します。
- SmartArt ノードの位置、階層、テキストなどの情報を取得して表示します。
  ```c#
  // 必要なプレゼンテーションを読み込む
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // 最初のスライド内のすべてのシェイプを走査
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // シェイプが SmartArt タイプか確認
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // シェイプを SmartArt に型変換
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // SmartArt 内のすべてのノードを走査
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // インデックス i の SmartArt ノードにアクセス
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // SmartArt ノードのパラメータを出力
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```


## **SmartArt 子ノードにアクセス**
以下のサンプルコードは、SmartArt シェイプの各ノードに属する子ノードにアクセスする方法を示します。

- `PresentationEx` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArtEx に型変換します。
- SmartArt シェイプ内のすべてのノードを走査します。
- 各選択された SmartArt シェイプノードについて、該当ノード内のすべての子ノードを走査します。
- 子ノードの位置、階層、テキストなどの情報を取得して表示します。
```c#
 // 目的のプレゼンテーションを読み込む
 Presentation pres = new Presentation("AccessChildNodes.pptx");

 // 最初のスライド内のすべてのシェイプを走査
 foreach (IShape shape in pres.Slides[0].Shapes)
 {

     // シェイプが SmartArt タイプか確認
     if (shape is Aspose.Slides.SmartArt.SmartArt)
     {

         // シェイプを SmartArt に型変換
         Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

         // SmartArt 内のすべてのノードを走査
         for (int i = 0; i < smart.AllNodes.Count; i++)
         {
             // インデックス i の SmartArt ノードにアクセス
             Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

             // インデックス i の SmartArt ノード内の子ノードを走査
             for (int j = 0; j < node0.ChildNodes.Count; j++)
             {
                 // SmartArt ノードの子ノードにアクセス
                 Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                 // SmartArt 子ノードのパラメータを出力
                 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                 Console.WriteLine(outString);
             }
         }
     }
 }
```


## **特定の位置に SmartArt 子ノードにアクセス**
この例では、SmartArt シェイプの各ノードに属する子ノードを特定の位置で取得する方法を学びます。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用して最初のスライドの参照を取得します。
- StackedList タイプの SmartArt シェイプを追加します。
- 追加した SmartArt シェイプにアクセスします。
- インデックス 0 のノードにアクセスします。
- `GetNodeByPosition()` メソッドを使用して、取得した SmartArt ノードの位置 1 の子ノードにアクセスします。
- 子ノードの位置、階層、テキストなどの情報を取得して表示します。
```c#
 // プレゼンテーションをインスタンス化
 Presentation pres = new Presentation();

 // 最初のスライドにアクセス
 ISlide slide = pres.Slides[0];

 // 最初のスライドに SmartArt シェイプを追加
 ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

 // インデックス 0 の SmartArt ノードにアクセス
 ISmartArtNode node = smart.AllNodes[0];

 // 親ノードの位置 1 の子ノードにアクセス
 int position = 1;
 SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

 // SmartArt 子ノードのパラメータを出力
 string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
 Console.WriteLine(outString);
```


## **SmartArt ノードを削除**
この例では、SmartArt シェイプ内のノードを削除する方法を学びます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
- SmartArt に 0 以上のノードがあるか確認します。
- 削除する SmartArt ノードを選択します。
- `RemoveNode()` メソッドを使用して選択したノードを削除し、プレゼンテーションを保存します。
```c#
// 必要なプレゼンテーションを読み込む
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // 最初のスライド内のすべてのシェイプを走査
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // シェイプが SmartArt タイプか確認
        if (shape is ISmartArt)
        {
            // シェイプを SmartArtEx に型変換
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // インデックス 0 の SmartArt ノードにアクセス
                ISmartArtNode node = smart.AllNodes[0];

                // 選択したノードを削除
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // プレゼンテーションを保存
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **特定の位置に SmartArt ノードを削除**
この例では、特定の位置にある SmartArt シェイプのノードを削除する方法を学びます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
- インデックス 0 の SmartArt シェイプノードを選択します。
- 選択した SmartArt ノードに 2 つ以上の子ノードがあるか確認します。
- `RemoveNodeByPosition()` メソッドを使用して位置 1 のノードを削除します。
- プレゼンテーションを保存します。
```c#
// 目的のプレゼンテーションを読み込む             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Traverse through every shape inside first slide
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // シェイプが SmartArt タイプか確認
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // シェイプを SmartArt に型変換
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // インデックス 0 の SmartArt ノードにアクセス
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // 位置 1 の子ノードを削除
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// プレゼンテーションを保存
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **SmartArt 子ノードのカスタム位置を設定**
現在、Aspose.Slides for .NET は SmartArtShape の X および Y プロパティの設定に対応しています。以下のコードスニペットは、カスタム位置、サイズ、回転を設定する方法を示します。新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることに注意してください。
```c#
// 目的のプレゼンテーションを読み込む
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// SmartArt シェイプを新しい位置に移動
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// SmartArt シェイプの幅を変更
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// SmartArt シェイプの高さを変更
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// SmartArt シェイプの回転を変更
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```


## **アシスタント ノードを確認**
以下のサンプルコードでは、SmartArt ノードコレクション内のアシスタント ノードを特定し、通常ノードに変更する方法を調査します。

- `PresentationEx` クラスのインスタンスを作成し、SmartArt シェイプが含まれるプレゼンテーションをロードします。
- インデックスを使用して 2 番目のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArtEx に型変換します。
- SmartArt シェイプ内のすべてのノードを走査し、アシスタント ノードかどうかチェックします。
- アシスタント ノードの状態を通常ノードに変更します。
- プレゼンテーションを保存します。
```c#
// プレゼンテーション インスタンスを作成
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // 最初のスライド内のすべてのシェイプを走査
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // シェイプが SmartArt タイプか確認
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // シェイプを SmartArtEx に型変換
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // SmartArt シェイプのすべてのノードを走査

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // ノードがアシスタント ノードか確認
                if (node.IsAssistant)
                {
                    // アシスタント ノードを false に設定し、通常ノードに変更
                    node.IsAssistant = false;
                }
            }
        }
    }
    // プレゼンテーションを保存
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **ノードの FillFormat を設定**
Aspose.Slides for .NET を使用すると、カスタム SmartArt シェイプを追加し、FillFormat を設定できます。本記事では、SmartArt シェイプを作成・アクセスし、FillFormat を設定する手順を説明します。

手順:

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutType を設定して SmartArt シェイプを追加します。
- SmartArt シェイプのノードに対して FillFormat を設定します。
- 変更したプレゼンテーションを PPTX ファイルとして保存します。
```c#
using (Presentation presentation = new Presentation())
{
    // スライドにアクセス
    ISlide slide = presentation.Slides[0];

    // SmartArt シェイプとノードを追加
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // ノードの塗りつぶし色を設定
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // プレゼンテーションを保存
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```


## **SmartArt 子ノードのサムネイルを生成**
開発者は以下の手順で SmartArt の子ノードのサムネイルを生成できます。

1. PPTX ファイルを表す `Presentation` クラスのインスタンスを作成します。
1. SmartArt を追加します。
1. インデックスを使用してノードの参照を取得します。
1. サムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

以下の例は SmartArt 子ノードのサムネイルを生成するものです。
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```


## **FAQ**

**SmartArt のアニメーションはサポートされていますか？**

はい。SmartArt は通常のシェイプとして扱われるため、[標準アニメーションを適用](/slides/ja/net/shape-animation/)（入場、退出、強調、モーション パス）でき、タイミングの調整も可能です。必要に応じて SmartArt ノード内のシェイプにもアニメーションを適用できます。

**スライド上の特定の SmartArt を内部 ID が不明な場合、確実に見つける方法はありますか？**

[代替テキスト](/slides/ja/net/shape-alternativetext/) を設定して検索します。SmartArt にユニークな AltText を設定すれば、内部識別子に依存せずプログラムから取得できます。

**プレゼンテーションを PDF に変換したとき、SmartArt の外観は維持されますか？**

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/net/convert-powerpoint-to-pdf/) 時に SmartArt を高いビジュアル忠実度でレンダリングし、レイアウト、色、効果を保持します。

**SmartArt 全体の画像を取得してプレビューやレポートに使用できますか？**

はい。SmartArt シェイプを [ラスタ形式](/slides/ja/net/shape-getimage/) または [SVG](/slides/ja/net/shape-writeassvg/) にレンダリングでき、サムネイル、レポート、Web 用に適した形で出力できます。