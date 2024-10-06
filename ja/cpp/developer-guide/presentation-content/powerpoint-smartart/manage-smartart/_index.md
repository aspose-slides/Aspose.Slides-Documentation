---
title: スマートアートの管理
type: docs
weight: 10
url: /ja/cpp/manage-smartart/
---

## **スマートアートからテキストを取得**
現在、ISmartArtShapeインターフェースおよびSmartArtShapeクラスにTextFrameプロパティが追加されました。このプロパティを使用すると、ノードのテキストだけでなく、スマートアートからすべてのテキストを取得できます。以下のサンプルコードは、スマートアートノードからテキストを取得するのに役立ちます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-GetTextFromSmartArtNode-GetTextFromSmartArtNode.cpp" >}}

## **スマートアートのレイアウトタイプを変更**
スマートアートのレイアウトタイプを変更するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- SmartArt BasicBlockListを追加します。
- LayoutTypeをBasicProcessに変更します。
- プレゼンテーションをPPTXファイルとして保存します。
  下記の例では、2つのシェイプ間にコネクタを追加しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **スマートアートの隠れたプロパティを確認**
メソッドcom.aspose.slides.ISmartArtNode.isHidden()は、このノードがデータモデル内の隠れたノードである場合にtrueを返すことに注意してください。スマートアートの任意のノードの隠れたプロパティを確認するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
- SmartArt RadialCycleを追加します。
- スマートアートにノードを追加します。
- isHiddenプロパティを確認します。
- プレゼンテーションをPPTXファイルとして保存します。

下記の例では、2つのシェイプ間にコネクタを追加しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CheckSmartArtHiddenProperty-CheckSmartArtHiddenProperty.cpp" >}}

## **組織図タイプの取得または設定**
メソッドcom.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)は、現在のノードに関連する組織図タイプを取得または設定することを可能にします。組織図タイプを取得または設定するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
- スライドにスマートアートを追加します。
- 組織図タイプを取得または設定します。
- プレゼンテーションをPPTXファイルとして保存します。
  下記の例では、2つのシェイプ間にコネクタを追加しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-OrganizeChartLayoutType-OrganizeChartLayoutType.cpp" >}}

## **スマートアートの状態の取得または設定**
いくつかのスマートアート図は反転をサポートしていません。たとえば、垂直バレットリスト、垂直プロセス、降順プロセス、ファネル、ギア、バランス、円関係、六角形クラスター、逆リスト、スタック型ベン図などです。スマートアートの向きを変更するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
- スライドにスマートアートを追加します。
- スマートアート図の状態を取得または設定します。
- プレゼンテーションをPPTXファイルとして保存します。
  下記の例では、2つのシェイプ間にコネクタを追加しました。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtLayout-ChangeSmartArtLayout.cpp" >}}

## **ピクチャ組織図の作成**
Aspose.Slides for C++は、簡単にピクチャ組織図を作成するためのシンプルなAPIを提供します。スライドにチャートを作成するには：

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
1. インデックスからスライドの参照を取得します。
1. デフォルトデータと共に、目的のタイプ（ChartType.PictureOrganizationChart）を持つチャートを追加します。
1. 修正されたプレゼンテーションをPPTXファイルに保存します。

以下のコードを使用してチャートを作成します。

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto smartArt = pres->get_Slides()->idx_get(0)->get_Shapes()->AddSmartArt(0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);
pres->Save(u"OrganizationChart.pptx", SaveFormat::Pptx);
```