---
title: スマートアートシェイプノードの管理
type: docs
weight: 30
url: /ja/net/manage-smartart-shape-node/
keywords:
- スマートアート
- スマートアート ノード
- スマートアート 子ノード
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint プレゼンテーションの SmartArt ノードと子ノードを管理する"
---

## **SmartArt ノードの追加**
Aspose.Slides for .NET は、SmartArt シェイプを最も簡単に管理できる API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードおよび子ノードを追加する方法を示します。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
- SmartArt の NodeCollection に新しいノードを追加し、TextFrame にテキストを設定します。
- 追加した SmartArt ノードに子ノードを追加し、TextFrame にテキストを設定します。
- プレゼンテーションを保存します。
```c#
// 指定したプレゼンテーションを読み込む
Presentation pres = new Presentation("AddNodes.pptx");

// 最初のスライド内のすべてのシェイプを走査する
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // シェイプが SmartArt タイプか確認する
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // シェイプを SmartArt に型変換する
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // 新しい SmartArt ノードを追加する
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // テキストを追加する
        TemNode.TextFrame.Text = "Test";

        // 親ノードに新しい子ノードを追加する。コレクションの末尾に追加されます
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // テキストを追加する
        newNode.TextFrame.Text = "New Node Added";

    }
}

// プレゼンテーションを保存する
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **特定の位置に SmartArt ノードを追加**
以下のサンプルコードでは、SmartArt シェイプの各ノードに属する子ノードを指定した位置に追加する方法を説明します。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用して最初のスライドの参照を取得します。
- アクセスしたスライドに StackedList タイプの SmartArt シェイプを追加します。
- 追加した SmartArt シェイプの最初のノードにアクセスします。
- 選択したノードの位置 2 に子ノードを追加し、テキストを設定します。
- プレゼンテーションを保存します。
```c#
// プレゼンテーション インスタンスを作成
Presentation pres = new Presentation();

// プレゼンテーションのスライドにアクセス
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
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプを追加したときにのみ設定されることに注意してください。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
- SmartArt シェイプ内のすべてのノードを走査します。
- SmartArt ノードの位置、レベル、テキストなどの情報を取得して表示します。
  ```c#
  // 指定したプレゼンテーションを読み込む
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // 最初のスライド内のすべてのシェイプを走査する
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // シェイプが SmartArt タイプか確認する
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // シェイプを SmartArt に型変換する
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // SmartArt 内のすべてのノードを走査する
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // インデックス i の SmartArt ノードにアクセスする
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // SmartArt ノードのパラメータを出力する
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
  ```


## **SmartArt 子ノードにアクセス**
以下のサンプルコードは、SmartArt シェイプの各ノードに属する子ノードにアクセスする方法を示します。

- `PresentationEx` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArtEx に型変換します。
- SmartArt シェイプ内のすべてのノードを走査します。
- 各選択した SmartArt シェイプノードについて、該当ノード内のすべての子ノードを走査します。
- 子ノードの位置、レベル、テキストなどの情報を取得して表示します。
```c#
// 指定したプレゼンテーションを読み込む
Presentation pres = new Presentation("AccessChildNodes.pptx");

// 最初のスライド内の全シェイプを走査する
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // シェイプが SmartArt タイプか確認する
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // シェイプを SmartArt に型変換する
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // SmartArt 内のすべてのノードを走査する
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // インデックス i の SmartArt ノードにアクセスする
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // インデックス i の SmartArt ノード内の子ノードを走査する
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // SmartArt ノードの子ノードにアクセスする
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // SmartArt 子ノードのパラメータを出力する
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```


## **特定の位置に SmartArt 子ノードをアクセス**
この例では、SmartArt シェイプの各ノードに属する子ノードを特定の位置で取得する方法を学びます。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用して最初のスライドの参照を取得します。
- StackedList タイプの SmartArt シェイプを追加します。
- 追加した SmartArt シェイプにアクセスします。
- インデックス 0 のノードにアクセスします。
- `GetNodeByPosition()` メソッドを使用して、対象 SmartArt ノードの位置 1 にある子ノードにアクセスします。
- 子ノードの位置、レベル、テキストなどの情報を取得して表示します。
```c#
// プレゼンテーションをインスタンス化
Presentation pres = new Presentation();

// 最初のスライドにアクセス
ISlide slide = pres.Slides[0];

// 最初のスライドに SmartArt シェイプを追加
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// インデックス 0 の SmartArt ノードにアクセス
ISmartArtNode node = smart.AllNodes[0];

// 親ノードの位置 1 にある子ノードにアクセス
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// SmartArt 子ノードのパラメータを出力
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```


## **SmartArt ノードの削除**
この例では、SmartArt シェイプ内のノードを削除する方法を学びます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
- SmartArt に 0 以上のノードがあるか確認します。
- 削除対象の SmartArt ノードを選択します。
- `RemoveNode()` メソッドを使用して選択したノードを削除し、プレゼンテーションを保存します。
```c#
// 指定されたプレゼンテーションを読み込む
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // 最初のスライド内のすべてのシェイプを走査する
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // シェイプが SmartArt タイプか確認する
        if (shape is ISmartArt)
        {
            // シェイプを SmartArtEx に型変換する
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // インデックス 0 の SmartArt ノードにアクセスする
                ISmartArtNode node = smart.AllNodes[0];

                // 選択したノードを削除する
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // プレゼンテーションを保存する
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **特定の位置に SmartArt ノードを削除**
この例では、SmartArt シェイプ内のノードを特定の位置で削除する方法を学びます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArt に型変換します。
- インデックス 0 の SmartArt シェイプノードを選択します。
- 選択した SmartArt ノードに 2 以上の子ノードがあるか確認します。
- `RemoveNodeByPosition()` メソッドを使用して位置 1 のノードを削除します。
- プレゼンテーションを保存します。
```c#
 // 指定したプレゼンテーションを読み込む             
 Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// 最初のスライド内のすべてのシェイプを走査する
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // シェイプが SmartArt タイプか確認する
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // シェイプを SmartArt に型変換する
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // インデックス 0 の SmartArt ノードにアクセスする
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // 位置 1 の子ノードを削除する
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// プレゼンテーションを保存する
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **子ノードのカスタム位置設定**
現在、Aspose.Slides for .NET は SmartArtShape の X および Y プロパティの設定をサポートしています。以下のコードスニペットは、SmartArtShape の位置、サイズ、回転をカスタム設定する方法を示します。新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることに注意してください。
```c#
// 指定されたプレゼンテーションを読み込む
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// SmartArt シェイプを新しい位置に移動する
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// SmartArt シェイプの幅を変更する
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// SmartArt シェイプの高さを変更する
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// SmartArt シェイプの回転を変更する
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```


## **アシスタント ノードの確認**
以下のサンプルコードでは、SmartArt ノードコレクション内のアシスタント ノードを特定し、通常のノードに変更する方法を調査します。

- `PresentationEx` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して 2 番目のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプか確認し、SmartArt であれば選択したシェイプを SmartArtEx に型変換します。
- SmartArt シェイプ内のすべてのノードを走査し、アシスタント ノードかどうかを確認します。
- アシスタント ノードのステータスを通常ノードに変更します。
- プレゼンテーションを保存します。
```c#
// プレゼンテーション インスタンスを作成
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // 最初のスライド内のすべてのシェイプを走査
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // シェイプが SmartArt タイプか確認する
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // シェイプを SmartArtEx に型変換する
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // SmartArt シェイプのすべてのノードを走査

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // ノードがアシスタント ノードかチェックする
                if (node.IsAssistant)
                {
                    // アシスタント ノードを false に設定し、通常ノードに変更する
                    node.IsAssistant = false;
                }
            }
        }
    }
    // プレゼンテーションを保存
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **ノードの塗りつぶし形式の設定**
Aspose.Slides for .NET を使用すると、カスタム SmartArt シェイプを追加し、その塗りつぶし形式を設定できます。本記事では、SmartArt シェイプの作成・アクセス方法と、塗りつぶし形式の設定手順を説明します。

以下の手順に従ってください。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutType を設定して SmartArt シェイプを追加します。
- SmartArt シェイプのノードに対して FillFormat を設定します。
- 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。
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


## **SmartArt 子ノードのサムネイル生成**
開発者は以下の手順で SmartArt の子ノードのサムネイルを生成できます。

1. PPTX ファイルを表す `Presentation` クラスのインスタンスを作成します。
2. SmartArt を追加します。
3. インデックスを使用してノードの参照を取得します。
4. サムネイル画像を取得します。
5. 任意の画像形式でサムネイル画像を保存します。

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

はい。SmartArt は通常のシェイプとして扱われるため、[標準アニメーション](/slides/ja/net/shape-animation/)（出現、退出、強調、モーション パス）を適用し、タイミングを調整できます。また、必要に応じて SmartArt ノード内部のシェイプにもアニメーションを付けられます。

**スライド上で内部 ID が不明な特定の SmartArt を確実に見つけるには？**

[代替テキスト]((https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/)) を設定して検索します。SmartArt に固有の AltText を付与すれば、内部識別子に依存せずにプログラムから取得できます。

**プレゼンテーションを PDF に変換した際、SmartArt の外観は保持されますか？**

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/net/convert-powerpoint-to-pdf/) 時に SmartArt を高いビジュアル忠実度でレンダリングし、レイアウト、色、効果を保持します。

**SmartArt 全体の画像（プレビューやレポート用）を抽出できますか？**

はい。SmartArt シェイプを [ラスタ形式]((https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)) または [SVG]((https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)) にレンダリングでき、サムネイル、レポート、Web 用に適した形式で取得できます。