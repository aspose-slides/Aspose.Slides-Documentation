---
title: シェイプサムネイルを作成する
type: docs
weight: 70
url: /ja/python-net/create-shape-thumbnails/
keywords: "シェイプサムネイル。PowerPointプレゼンテーション、Python、Aspose.Slides for Python via .NET"
description: "PythonにおけるPowerPointプレゼンテーションのシェイプサムネイル"
---

Aspose.Slides for Python via .NETは、各ページがスライドであるプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションファイルを開くことで表示できます。しかし、時には開発者が画像ビューワーでシェイプの画像を別々に表示する必要がある場合があります。そのような場合、Aspose.Slides for Python via .NETはスライドシェイプのサムネイル画像を生成するのに役立ちます。この機能の使い方についてはこの記事で説明します。
この記事では、さまざまな方法でスライドのサムネイルを生成する方法を説明します。

- スライド内のシェイプサムネイルを生成する。
- ユーザー定義の寸法を持つスライドシェイプのシェイプサムネイルを生成する。
- シェイプの外観の境界内にシェイプサムネイルを生成する。
- SmartArtの子ノードのサムネイルを生成する。
## **スライドからシェイプサムネイルを生成する**
Aspose.Slides for Python via .NETを使用して任意のスライドからシェイプサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドのシェイプサムネイル画像をデフォルトスケールで取得します。
1. 目的の画像形式でサムネイル画像を保存します。

以下の例は、シェイプサムネイルを生成します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # フルスケール画像を作成
    with presentation.slides[0].shapes[0].get_image() as bitmap:
        # PNG形式でディスクに画像を保存
        bitmap.save("Shape_thumbnail_out.png", slides.ImageFormat.PNG)
```


## **ユーザー定義スケーリングファクターサムネイルを生成する**
Aspose.Slides for Python via .NETを使用して任意のスライドシェイプのシェイプサムネイルを生成するには：

1. `Presentation`クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. シェイプの境界を持つ参照されたスライドのサムネイル画像を取得します。
1. 目的の画像形式でサムネイル画像を保存します。

以下の例は、ユーザー定義のスケーリングファクターを持つサムネイルを生成します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation(path + "HelloWorld.pptx") as p:
    # フルスケール画像を作成
    with p.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.SHAPE, 1, 1) as bitmap:
        # PNG形式でディスクに画像を保存
        bitmap.save("Scaling Factor Thumbnail_out.png", slides.ImageFormat.PNG)
```


## **外観の境界にシェイプサムネイルを作成する**
このシェイプのサムネイルを作成する方法は、開発者がシェイプの外観の境界内にサムネイルを生成できるようにします。これはすべてのシェイプ効果を考慮に入れています。生成されたシェイプサムネイルは、スライドの境界によって制限されます。シェイプの外観の境界内にある任意のスライドシェイプのサムネイルを生成するには、次のサンプルコードを使用します。

1. `Presentation`クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. 外観としてのシェイプ境界を持つ参照されたスライドのサムネイル画像を取得します。
1. 目的の画像形式でサムネイル画像を保存します。

以下の例は、ユーザー定義のスケーリングファクターを持つサムネイルを生成します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # 外観境界シェイプ画像を作成
    with presentation.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.APPEARANCE, 1, 1) as bitmap:
        # PNG形式でディスクに画像を保存
        bitmap.save("Shape_thumbnail_Bound_Shape_out.png", slides.ImageFormat.PNG)
```