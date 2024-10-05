---
title: SmartArt シェイプノードの管理
type: docs
weight: 30
url: /net/manage-smartart-shape-node/
keywords:
- SmartArt
- SmartArt ノード
- SmartArt 子ノード
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C# または .NET で PowerPoint プレゼンテーションの SmartArt ノードと子ノードを管理します"
---


## **SmartArt ノードを追加する**
Aspose.Slides for .NET は、SmartArt シェイプを簡単に管理するための最もシンプルな API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードと子ノードを追加するのに役立ちます。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションを読み込みます。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプをトラバースします。
- シェイプが SmartArt タイプであるかを確認し、SmartArt であれば選択したシェイプを型キャストします。
- SmartArt シェイプの NodeCollection に新しいノードを追加し、TextFrame にテキストを設定します。
- 次に、新しく追加した SmartArt ノードに子ノードを追加し、TextFrame にテキストを設定します。
- プレゼンテーションを保存します。

```c#
// 読み込むプレゼンテーションを取得
Presentation pres = new Presentation("AddNodes.pptx");

// 最初のスライド内のすべてのシェイプをトラバース
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // シェイプが SmartArt タイプであるかを確認
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // シェイプを SmartArt に型キャスト
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // 新しい SmartArt ノードを追加
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // テキストを追加
        TemNode.TextFrame.Text = "テスト";

        // 親ノードに新しい子ノードを追加。コレクションの最後に追加されます
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // テキストを追加
        newNode.TextFrame.Text = "新しいノードが追加されました";

    }
}

// プレゼンテーションを保存
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **特定の位置に SmartArt ノードを追加する**
次のサンプルコードでは、SmartArt シェイプに属する各ノードの子ノードを特定の位置に追加する方法を説明しています。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用して最初のスライドの参照を取得します。
- アクセスしたスライドに StackedList タイプの SmartArt シェイプを追加します。
- 追加された SmartArt シェイプの最初のノードにアクセスします。
- 選択したノードに対して位置 2 で子ノードを追加し、そのテキストを設定します。
- プレゼンテーションを保存します。

```c#
// プレゼンテーションのインスタンスを作成
Presentation pres = new Presentation();

// プレゼンテーションスライドにアクセス
ISlide slide = pres.Slides[0];

// Smart Art IShape を追加
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// インデックス 0 で SmartArt ノードにアクセス
ISmartArtNode node = smart.AllNodes[0];

// 親ノードの位置 2 で新しい子ノードを追加
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// テキストを追加
chNode.TextFrame.Text = "サンプル テキストが追加されました";

// プレゼンテーションを保存
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **SmartArt ノードにアクセスする**
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスするのに役立ちます。SmartArt シェイプが追加されるときにのみ設定されるため、SmartArt の LayoutType を変更できないことに注意してください。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションを読み込みます。

- インデックスを使用して最初のスライドの参照を取得します。

- 最初のスライド内のすべてのシェイプをトラバースします。

- シェイプが SmartArt タイプであるかを確認し、SmartArt であれば選択したシェイプを型キャストします。

- SmartArt シェイプ内のすべてのノードをトラバースします。

- SmartArt ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

```c#
// 読み込むプレゼンテーションを取得
Presentation pres = new Presentation("AccessSmartArt.pptx");

// 最初のスライド内のすべてのシェイプをトラバース
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // シェイプが SmartArt タイプであるかを確認
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // シェイプを SmartArt に型キャスト
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // SmartArt 内のすべてのノードをトラバース
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // インデックス i の SmartArt ノードにアクセス
            Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // SmartArt ノードパラメータを出力
            string outString = string.Format("i = {0}, テキスト = {1}, レベル = {2}, 位置 = {3}", i, node.TextFrame.Text, node.Level, node.Position);
            Console.WriteLine(outString);
        }
    }
}
```

  


## **SmartArt 子ノードにアクセスする**
以下のサンプルコードは、SmartArt シェイプの各ノードに属する子ノードにアクセスするのに役立ちます。

- `PresentationEx` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションを読み込みます。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプをトラバースします。
- シェイプが SmartArt タイプであるかを確認し、SmartArt であれば選択したシェイプを SmartArtEx に型キャストします。
- SmartArt シェイプ内のすべてのノードをトラバースします。
- 各選択された SmartArt シェイプノードについて、特定のノード内のすべての子ノードをトラバースします。
- 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

```c#
// 読み込むプレゼンテーションを取得
Presentation pres = new Presentation("AccessChildNodes.pptx");

// 最初のスライド内のすべてのシェイプをトラバース
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // シェイプが SmartArt タイプであるかを確認
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // シェイプを SmartArt に型キャスト
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // SmartArt 内のすべてのノードをトラバース
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // インデックス i の SmartArt ノードにアクセス
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // インデックス i の SmartArt ノード内の子ノードをトラバース
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // SmartArt ノード内の子ノードにアクセス
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // SmartArt 子ノードパラメータを出力
                string outString = string.Format("j = {0}, テキスト = {1}, レベル = {2}, 位置 = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **特定の位置に SmartArt 子ノードにアクセスする**
この例では、SmartArt シェイプのそれぞれのノードに属する子ノードに特定の位置でアクセスする方法を学びます。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用して最初のスライドの参照を取得します。
- StackedList タイプの SmartArt シェイプを追加します。
- 追加した SmartArt シェイプにアクセスします。
- アクセスした SmartArt シェイプのインデックス 0 のノードにアクセスします。
- 次に、GetNodeByPosition() メソッドを使用して、アクセスした SmartArt ノードの位置 1 にある子ノードにアクセスします。
- 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

```c#
// プレゼンテーションのインスタンスを作成
Presentation pres = new Presentation();

// 最初のスライドにアクセス
ISlide slide = pres.Slides[0];

// 最初のスライドに SmartArt シェイプを追加
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// インデックス 0 で SmartArt ノードにアクセス
ISmartArtNode node = smart.AllNodes[0];

// 親ノードの位置 1 の子ノードにアクセス
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// SmartArt 子ノードパラメータを出力
string outString = string.Format("j = {0}, テキスト = {1}, レベル = {2}, 位置 = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **SmartArt ノードを削除する**
この例では、SmartArt シェイプ内のノードを削除する方法を学びます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションを読み込みます。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプをトラバースします。
- シェイプが SmartArt タイプであるかを確認し、SmartArt であれば選択したシェイプを型キャストします。
- SmartArt にノードが 0 より多いかを確認します。
- 削除する SmartArt ノードを選択します。
- 次に、RemoveNode() メソッドを使用して選択したノードを削除します。プレゼンテーションを保存します。

```c#
// 読み込むプレゼンテーションを取得
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // 最初のスライド内のすべてのシェイプをトラバース
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // シェイプが SmartArt タイプであるかを確認
        if (shape is ISmartArt)
        {
            // シェイプを SmartArtEx に型キャスト
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



## **特定の位置に SmartArt ノードを削除する**
この例では、特定の位置で SmartArt シェイプ内のノードを削除する方法を学びます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションを読み込みます。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプをトラバースします。
- シェイプが SmartArt タイプであるかを確認し、SmartArt であれば選択したシェイプを型キャストします。
- インデックス 0 で SmartArt シェイプノードを選択します。
- 選択された SmartArt ノードに 2 つ以上の子ノードがあるかを確認します。
- 次に、RemoveNodeByPosition() メソッドを使用して位置 1 のノードを削除します。
- プレゼンテーションを保存します。

```c#
// 読み込むプレゼンテーションを取得             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// 最初のスライド内のすべてのシェイプをトラバース
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // シェイプが SmartArt タイプであるかを確認
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // シェイプを SmartArt に型キャスト
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



## **SmartArt の子ノードにカスタム位置を設定する**
Aspose.Slides for .NET では、SmartArtShape の X および Y プロパティを設定できるようになりました。以下のコードスニペットは、SmartArtShape の位置、サイズ、および回転をカスタム設定する方法を示します。また、新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることに注意してください。

```c#
// 読み込むプレゼンテーションを取得
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



## **アシスタントノードの確認**
以下のサンプルコードでは、SmartArt ノードコレクション内のアシスタントノードを特定し、それを変更する方法を調査します。

- `PresentationEx` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションを読み込みます。
- インデックスを使用して 2 番目のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプをトラバースします。
- シェイプが SmartArt タイプであるかを確認し、SmartArt であれば選択したシェイプを SmartArtEx に型キャストします。
- SmartArt シェイプ内のすべてのノードをトラバースし、それらがアシスタントノードであるかを確認します。
- アシスタントノードの状態を通常のノードに変更します。
- プレゼンテーションを保存します。

```c#
// プレゼンテーション インスタンスを作成
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // 最初のスライド内のすべてのシェイプをトラバース
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // シェイプが SmartArt タイプであるかを確認
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // シェイプを SmartArtEx に型キャスト
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // SmartArt シェイプのすべてのノードをトラバース

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // ノードがアシスタントノードであるかを確認
                if (node.IsAssistant)
                {
                    // アシスタントノードを false に設定し、通常のノードに変更
                    node.IsAssistant = false;
                }
            }
        }
    }
    // プレゼンテーションを保存
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **ノードの塗りつぶしフォーマットを設定する**
Aspose.Slides for .NET を使用すると、カスタム SmartArt 形状を追加し、その塗りつぶしフォーマットを設定できます。この文章では、SmartArt 形状を作成してその塗りつぶしフォーマットを設定する方法を説明します。

以下の手順に従ってください：

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutType を設定して SmartArt シェイプを追加します。
- SmartArt シェイプノードの FillFormat を設定します。
- 変更したプレゼンテーションを PPTX ファイルとして書き込みます。

```c#
using (Presentation presentation = new Presentation())
{
    // スライドを取得
    ISlide slide = presentation.Slides[0];

    // SmartArt シェイプとノードを追加
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "サンプルテキスト";

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



## **SmartArt 子ノードのサムネイルを生成する**
開発者は、以下の手順に従って SmartArt の子ノードのサムネイルを生成できます。

1. PPTX ファイルを表す `Presentation` クラスをインスタンス化します。
2. SmartArt を追加します。
3. インデックスを使用してノードの参照を取得します。
4. サムネイル画像を取得します。
5. 任意の画像形式でサムネイル画像を保存します。

以下の例では、SmartArt 子ノードのサムネイルを生成しています。

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