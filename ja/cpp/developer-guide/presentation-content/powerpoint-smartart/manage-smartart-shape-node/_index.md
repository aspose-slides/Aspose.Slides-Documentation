---
title: C++ を使用してプレゼンテーションで SmartArt シェイプ ノードを管理する
linktitle: SmartArt シェイプ ノード
type: docs
weight: 30
url: /ja/cpp/manage-smartart-shape-node/
keywords:
- SmartArt ノード
- 子ノード
- ノードの追加
- ノード位置
- ノードへのアクセス
- ノードの削除
- カスタム位置
- アシスタント ノード
- 塗りつぶし形式
- ノードのレンダリング
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PPT および PPTX の SmartArt シェイプ ノードを管理します。プレゼンテーションを効率化するためのわかりやすいコード例とヒントをご覧ください。"
---

## **SmartArt ノードの追加**
Aspose.Slides for C++ は、SmartArt シェイプを最も簡単に管理できる API を提供しています。以下のサンプルコードは、SmartArt シェイプ内にノードと子ノードを追加する方法を示しています。

- Presentation クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt の場合は選択したシェイプを SmartArt に型キャストします。
- SmartArt シェイプの NodeCollection に新しい Node を追加し、TextFrame にテキストを設定します。
- 次に、追加した SmartArt ノードに子ノードを追加し、TextFrame にテキストを設定します。
- プレゼンテーションを保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **特定の位置に SmartArt ノードを追加**
以下のサンプルコードでは、SmartArt シェイプの各ノードに属する子ノードを特定の位置に追加する方法を説明します。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用して最初のスライドの参照を取得します。
- 取得したスライドに StackedList タイプの SmartArt シェイプを追加します。
- 追加した SmartArt シェイプの最初のノードにアクセスします。
- 次に、選択したノードの位置 2 に子ノードを追加し、テキストを設定します。
- プレゼンテーションを保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **SmartArt ノードへのアクセス**
以下のサンプルコードは、SmartArt シェイプ内のノードにアクセスする方法を示します。SmartArt の LayoutType は読み取り専用で、SmartArt シェイプを追加したときにのみ設定されるため、変更できないことに注意してください。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt の場合は選択したシェイプを SmartArt に型キャストします。
- SmartArt シェイプ内のすべての Node を走査します。
- SmartArt ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **SmartArt 子ノードへのアクセス**
以下のサンプルコードは、SmartArt シェイプ内の子ノードにアクセスする方法を示します。

- PresentationEx クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt の場合は選択したシェイプを SmartArtEx に型キャストします。
- SmartArt シェイプ内のすべての Node を走査します。
- 選択した SmartArt シェイプの各 Node について、該当ノード内のすべての子ノードを走査します。
- 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **特定の位置に SmartArt 子ノードをアクセス**
以下のサンプルコードでは、SmartArt シェイプの特定の位置にある子ノードにアクセスする方法を示します。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用して最初のスライドの参照を取得します。
- StackedList タイプの SmartArt シェイプを追加します。
- 追加した SmartArt シェイプにアクセスします。
- アクセスした SmartArt シェイプのインデックス 0 のノードにアクセスします。
- 次に、GetNodeByPosition() メソッドを使用して、アクセスした SmartArt ノードの位置 1 の子ノードにアクセスします。
- 子ノードの位置、レベル、テキストなどの情報にアクセスして表示します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **SmartArt ノードの削除**
この例では、SmartArt シェイプ内のノードを削除する方法を学びます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt の場合は選択したシェイプを SmartArt に型キャストします。
- SmartArt に 0 以上のノードがあるか確認します。
- 削除対象の SmartArt ノードを選択します。
- 今、RemoveNode() メソッドを使用して選択したノードを削除します* プレゼンテーションを保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **特定の位置に SmartArt ノードを削除**
この例では、SmartArt シェイプ内のノードを特定の位置で削除する方法を学びます。

- `Presentation` クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt の場合は選択したシェイプを SmartArt に型キャストします。
- インデックス 0 の SmartArt シェイプノードを選択します。
- 次に、選択した SmartArt ノードに 2 つ以上の子ノードがあるか確認します。
- 次に、RemoveNodeByPosition() メソッドを使用して位置 1 のノードを削除します。
- プレゼンテーションを保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **SmartArt 子ノードのカスタム位置設定**
現在、Aspose.Slides は SmartArtShape の X および Y プロパティの設定をサポートしています。以下のコードスニペットは、カスタム SmartArtShape の位置、サイズ、回転の設定方法を示します。また、新しいノードを追加すると、すべてのノードの位置とサイズが再計算されることに注意してください。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **アシスタント ノードの確認**
以下のサンプルコードでは、SmartArt ノードコレクション内のアシスタント ノードを特定し、変更する方法を調査します。

- PresentationEx クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
- インデックスを使用して2番目のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプを走査します。
- シェイプが SmartArt タイプかどうかを確認し、SmartArt の場合は選択したシェイプを SmartArtEx に型キャストします。
- SmartArt シェイプ内のすべてのノードを走査し、アシスタント ノードかどうかを確認します。
- アシスタント ノードのステータスを通常ノードに変更します。
- プレゼンテーションを保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **ノードの FillFormat 設定**
Aspose.Slides for C++ は、カスタム SmartArt シェイプを追加し、その塗りつぶし形式を設定することを可能にします。この記事では、SmartArt シェイプを作成およびアクセスし、Aspose.Slides for C++ を使用して塗りつぶし形式を設定する方法を説明します。

以下の手順に従ってください。

- `Presentation` クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutType を設定して SmartArt シェイプを追加します。
- SmartArt シェイプのノードに FillFormat を設定します。
- 変更したプレゼンテーションを書き出して PPTX ファイルとして保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **SmartArt 子ノードのサムネイル生成**
開発者は以下の手順に従って SmartArt の子ノードのサムネイルを生成できます。

1. PPTX ファイルを表す `Presentation` クラスのインスタンスを作成します。
2. SmartArt を追加します。
3. インデックスを使用してノードの参照を取得します。
4. サムネイル画像を取得します。
5. 任意の画像形式でサムネイル画像を保存します。

以下の例は SmartArt 子ノードのサムネイルを生成します
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **FAQ**

**SmartArt のアニメーションはサポートされていますか？**

はい。SmartArt は通常のシェイプとして扱われるため、[標準アニメーション](/slides/ja/cpp/shape-animation/)（入口、退出、強調、モーションパス）を適用し、タイミングを調整できます。また、必要に応じて SmartArt ノード内のシェイプにもアニメーションを付けることができます。

**内部 ID が不明な場合、スライド上の特定の SmartArt を確実に見つける方法は？**

[代替テキスト](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_alternativetext/) を設定して検索します。SmartArt に特徴的な AltText を設定すれば、内部 ID に依存せずにプログラムから検索できます。

**プレゼンテーションを PDF に変換するとき、SmartArt の外観は保持されますか？**

はい。Aspose.Slides は [PDF エクスポート](/slides/ja/cpp/convert-powerpoint-to-pdf/) 時に SmartArt を高い視覚忠実度でレンダリングし、レイアウト、色、エフェクトを保持します。

**SmartArt 全体の画像を取得できるか（プレビューやレポート用）？**

はい。SmartArt シェイプを [ラスタ形式](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) や [SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) でレンダリングして、拡大縮小可能なベクタ出力を取得できます。これによりサムネイル、レポート、ウェブでの使用に適しています。