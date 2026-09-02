---
title: C++ で PowerPoint プレゼンテーションを XML に変換
linktitle: PowerPoint から XML へ
type: docs
weight: 145
url: /ja/cpp/convert-powerpoint-to-xml/
keywords:
- PowerPoint を XML に変換
- プレゼンテーションを XML に変換
- PPT を XML に変換
- PPTX を XML に変換
- ODP を XML に変換
- PowerPoint XML プレゼンテーション
- SaveFormat::Xml
- プレゼンテーションを XML として保存
- プレゼンテーションを XML にエクスポート
- XML ストリーム
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションを C++ で PowerPoint XML ファイルまたはストリームに変換します。"
---
## **概要**

Aspose.Slides for C++ は PowerPoint プレゼンテーションを PowerPoint XML プレゼンテーション形式に変換できます。XML 出力は、プレゼンテーションの構造を確認したり、生成されたドキュメントのトラブルシューティングを行ったり、自動テストで出力を比較したり、プレゼンテーション パッケージではなく XML を消費するワークフローと統合したりする際に、テキストベースの表現が必要な場合に便利です。

Presentation::Save メソッドを使用し、SaveFormat 列挙体の Xml 値を指定します。結果はファイルに直接書き込むことも、ストリームに書き込むこともできます。

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` は PowerPoint XML プレゼンテーションを作成します。PPTX パッケージ内に格納されている個々の Office Open XML パーツを抽出するわけではありません。`ppt/presentation.xml` や個々のスライド XML ファイルなど、正確な PPTX パッケージのパーツが必要な場合は、PPTX パッケージ自体を確認してください。
{{% /alert %}}

## **プレゼンテーションを XML ファイルに変換する**

Presentation クラスでソース プレゼンテーションを読み込み、出力パスと `SaveFormat::Xml` を Presentation::Save に渡します。ソースは PPT、PPTX、ODP など、読み込みがサポートされている任意のプレゼンテーション形式にできます。

以下の例は PPTX プレゼンテーションを XML ファイルに変換します：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **XML 出力をストリームに書き込む**

XML をメモリ内に保持したり、Web サービス、ストレージ プロバイダー、XML 処理パイプラインなど別のコンポーネントに渡したりする必要がある場合は、Presentation::Save のストリーム オーバーロードを使用します。以下の例は結果を [MemoryStream](https://reference.aspose.com/slides/ja/cpp/system.io/memorystream/) に書き込み、再度読み取れるようにシーク位置を先頭に戻します：

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// xmlStream をワークフローの次のコンポーネントに渡します。
```

## **XML とプレゼンテーションおよびエクスポート形式の比較**

結果の使用方法に応じて出力形式を選択してください：

| 形式 | 出力 | 典型的な使用例 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML プレゼンテーション | 構造の検査、トラブルシューティング、生成結果の比較、XML ベースの統合 |
| PPT (`.ppt`) | レガシーなバイナリ プレゼンテーション ファイル | 古い PowerPoint ワークフローとの互換性 |
| PPTX (`.pptx`) | 複数のパーツを含む Office Open XML パッケージ | 通常の PowerPoint 編集とプレゼンテーションのやり取り |
| PDF or TIFF | 固定レイアウトのページまたは複数ページの画像 | 閲覧、印刷、アーカイブ |
| PNG, JPEG, or SVG | 個々のスライドのレンダリング表現 | サムネイル、プレビュー、画像アセット |
| HTML or HTML5 | Web 向けプレゼンテーション出力 | ブラウザでの表示およびウェブ公開 |

PPT や PPTX とは異なり、XML 出力は主に検査やデータ指向のワークフローを目的としています。PDF、TIFF、HTML、スライド画像形式とは異なり、スライドをページやビジュアル資産としてレンダリングするのではなく、プレゼンテーション データを表現します。 [supported file formats](/slides/ja/cpp/supported-file-formats/) テーブルでは PowerPoint XML プレゼンテーションを保存専用形式として一覧に掲載しているため、エクスポートしたファイルを再度 Aspose.Slides に読み込んで編集を続行する必要があるワークフローでは使用しないでください。

## **よくある質問**

**`SaveFormat::Xml` は PPTX ファイルを保存するのと同じですか？**  
いいえ。PPTX は複数の Office Open XML パーツを含むパッケージですが、`SaveFormat::Xml` は PowerPoint XML プレゼンテーション ファイルを作成します。

**XML 出力をディスクにファイルを作成せずに保存できますか？**  
はい。書き込み可能なストリームを Presentation::Save に渡します。例えば、インメモリ処理のために MemoryStream を使用します。

**Aspose.Slides はエクスポートされた XML ファイルを再度読み込めますか？**  
いいえ。PowerPoint XML プレゼンテーションは現在保存のみがサポートされており、読み込みはサポートされていません。往復編集が必要な場合は PPTX などのサポートされているプレゼンテーション形式を使用してください。

**XML 変換は各スライドをページまたは画像としてレンダリングしますか？**  
いいえ。XML 変換は構造化されたプレゼンテーション データを書き出します。ページ指向の出力が必要な場合は PDF や TIFF を、個々のスライド画像が必要な場合は PNG、JPEG、SVG を使用してください。