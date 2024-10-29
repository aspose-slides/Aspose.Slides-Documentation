---
title: シェイプのサムネイルを作成する
type: docs
weight: 70
url: /ja/androidjava/create-shape-thumbnails/
---


## **概要**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Javaを使用すると、各ページがスライドに対応するプレゼンテーションファイルを作成できます。スライドは、Microsoft PowerPointを使用してプレゼンテーションファイルを開くことで表示できます。しかし、開発者は時々、画像ビューアでシェイプの画像を別々に表示する必要があります。そのような場合、Aspose.Slides for Android via Javaは、スライドシェイプのサムネイル画像を生成するのに役立ちます。

{{% /alert %}} 

このトピックでは、さまざまな状況でスライドのサムネイルを生成する方法を示します：

- スライド内のシェイプサムネイルを生成する。
- ユーザー定義の寸法でスライドシェイプのサムネイルを生成する。
- シェイプの外観の範囲でシェイプサムネイルを生成する。

## **スライドからシェイプのサムネイルを生成する**
Aspose.Slides for Android via Javaを使用して任意のスライドからシェイプのサムネイルを生成するには、以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. 参照したスライドの[シェイプサムネイル画像](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--)をデフォルトスケールで取得します。
1. お好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、スライドからシェイプのサムネイルを生成する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンス化
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケール画像を作成
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // 画像をPNG形式でディスクに保存
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **ユーザー定義スケーリングファクタでシェイプのサムネイルを生成する**
Aspose.Slides for Android via Javaを使用してスライドのシェイプサムネイルを生成するには、以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. ユーザー定義の寸法を持つ参照したスライドの[シェイプサムネイル画像](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-)を取得します。
1. お好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、定義されたスケーリングファクタに基づいてシェイプのサムネイルを生成する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンス化
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケール画像を作成
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // 画像をPNG形式でディスクに保存
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **外観の範囲内でシェイプのサムネイルを生成する**
このシェイプのサムネイルを作成する方法は、開発者がシェイプの外観の範囲内でサムネイルを生成できるようにします。これにより、すべてのシェイプエフェクトが考慮されます。生成されたシェイプサムネイルはスライドの範囲に制限されます。スライドシェイプの外観の範囲内でサムネイルを生成するには、以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して任意のスライドの参照を取得します。
1. シェイプの範囲として外観を持つ参照したスライドのサムネイル画像を取得します。
1. お好みの画像形式でサムネイル画像を保存します。

このサンプルコードは、上記の手順に基づいています：

```java
// プレゼンテーションファイルを表すPresentationクラスのインスタンス化
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // フルスケール画像を作成
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // 画像をPNG形式でディスクに保存
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```