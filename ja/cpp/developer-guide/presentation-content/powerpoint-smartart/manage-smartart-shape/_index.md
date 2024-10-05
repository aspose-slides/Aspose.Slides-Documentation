---
title: SmartArtシェイプを管理する
type: docs
weight: 20
url: /cpp/manage-smartart-shape/
---


## **SmartArtシェイプを作成する**
Aspose.Slides for C++は、スライドにカスタムSmartArtシェイプをゼロから追加する機能を提供します。Aspose.Slides for C++は、SmartArtシェイプを最も簡単に作成するためのシンプルなAPIを提供しています。スライドにSmartArtシェイプを作成するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- LayoutTypeを設定してSmartArtシェイプを追加します。
- 修正されたプレゼンテーションをPPTXファイルとして保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateSmartArtShape-CreateSmartArtShape.cpp" >}}


## **スライド内のSmartArtシェイプにアクセスする**
以下のコードは、プレゼンテーションスライドに追加されたSmartArtシェイプにアクセスするために使用されます。サンプルコードでは、スライド内のすべてのシェイプをトラバースし、それがSmartArtシェイプかどうかを確認します。シェイプがSmartArtタイプであれば、それをSmartArtインスタンスに型変換します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtShape-AccessSmartArtShape.cpp" >}}

## **特定のLayoutTypeを持つSmartArtシェイプにアクセスする**
以下のサンプルコードは、特定のLayoutTypeを持つSmartArtシェイプにアクセスするのに役立ちます。SmartArtシェイプのLayoutTypeは読み取り専用であり、SmartArtシェイプが追加されたときにのみ設定されるため、変更できませんのでご注意ください。

- `Presentation` クラスのインスタンスを作成し、SmartArtシェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプをトラバースします。
- シェイプがSmartArtタイプかどうかを確認し、SmartArtの場合は選択したシェイプをSmartArtに型変換します。
- 特定のLayoutTypeを持つSmartArtシェイプを確認し、その後必要な処理を行います。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArtParticularLayout-AccessSmartArtParticularLayout.cpp" >}}


## **SmartArtシェイプスタイルを変更する**
以下のサンプルコードは、特定のLayoutTypeを持つSmartArtシェイプにアクセスするのに役立ちます。

- `Presentation` クラスのインスタンスを作成し、SmartArtシェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプをトラバースします。
- シェイプがSmartArtタイプかどうかを確認し、SmartArtの場合は選択したシェイプをSmartArtに型変換します。
- 特定のスタイルを持つSmartArtシェイプを見つけます。
- SmartArtシェイプの新しいスタイルを設定します。
- プレゼンテーションを保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangSmartArtShapeStyle-ChangSmartArtShapeStyle.cpp" >}}


## **SmartArtシェイプのカラースタイルを変更する**
この例では、任意のSmartArtシェイプのカラースタイルを変更する方法を学びます。以下のサンプルコードでは、特定のカラースタイルを持つSmartArtシェイプにアクセスし、そのスタイルを変更します。

- `Presentation` クラスのインスタンスを作成し、SmartArtシェイプを含むプレゼンテーションをロードします。
- インデックスを使用して最初のスライドの参照を取得します。
- 最初のスライド内のすべてのシェイプをトラバースします。
- シェイプがSmartArtタイプかどうかを確認し、SmartArtの場合は選択したシェイプをSmartArtに型変換します。
- 特定のカラースタイルを持つSmartArtシェイプを見つけます。
- SmartArtシェイプの新しいカラースタイルを設定します。
- プレゼンテーションを保存します。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeSmartArtShapeColorStyle-ChangeSmartArtShapeColorStyle.cpp" >}}