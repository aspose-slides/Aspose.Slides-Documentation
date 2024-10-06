---
title: シェイプサムネイルの作成
type: docs
weight: 70
url: /ja/java/create-shape-thumbnails/
---


## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for Javaは、各ページがスライドに対応するプレゼンテーションファイルを作成するために使用できます。スライドは、Microsoft PowerPointを使用してプレゼンテーションファイルを開くことで表示できます。ただし、開発者は時折、形状の画像を画像ビューアで別々に表示する必要があります。そのような場合、Aspose.Slides for Javaはスライド形状のサムネイル画像を生成するのに役立ちます。

{{% /alert %}} 

このトピックでは、異なる状況でスライドサムネイルを生成する方法を示します：

- スライド内のシェイプサムネイルを生成する。
- ユーザー定義の寸法を持つスライド形状のシェイプサムネイルを生成する。
- シェイプの外観の範囲内でシェイプサムネイルを生成する。

## **スライドからのシェイプサムネイルの生成**
Aspose.Slides for Javaを使用して任意のスライドからシェイプサムネイルを生成するには、以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. 参照されたスライドの[シェイプサムネイル画像](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--)をデフォルトスケールで取得します。
1. 希望する画像フォーマットでサムネイル画像を保存します。

このサンプルコードは、スライドからシェイプサムネイルを生成する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケール画像を作成
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // PNGフォーマットで画像をディスクに保存
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ユーザー定義のスケーリングファクタを持つシェイプサムネイルの生成**
Aspose.Slides for Javaを使用してスライドのシェイプサムネイルを生成するには、以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. ユーザー定義の寸法を持つ参照されたスライドの[シェイプサムネイル画像](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-)を取得します。
1. 希望する画像フォーマットでサムネイル画像を保存します。

このサンプルコードは、定義されたスケーリングファクタに基づいてシェイプサムネイルを生成する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケール画像を作成
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // PNGフォーマットで画像をディスクに保存
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **外観の範囲のシェイプサムネイルの生成**
このシェイプのサムネイルを作成する方法は、開発者がシェイプの外観の範囲内でサムネイルを生成できるようにします。すべてのシェイプ効果を考慮に入れます。生成されたシェイプサムネイルは、スライドの範囲によって制限されます。シェイプの外観の範囲内でスライドシェイプのサムネイルを生成するには、以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. 外観としてのシェイプ範囲を持つ参照されたスライドのサムネイル画像を取得します。
1. 希望する画像フォーマットでサムネイル画像を保存します。

このサンプルコードは、上記の手順に基づいています：

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケール画像を作成
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // PNGフォーマットで画像をディスクに保存
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```