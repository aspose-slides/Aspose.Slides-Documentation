---
title: Aspose.Slides for AndroidのJava経由でのインストール
type: docs
weight: 90
url: /ja/androidjava/install-aspose-slides-for-android-via-java/
---




## **インストール**
以前は、Aspose.Slides for Android via Javaは、JARファイル、デモ、および製品ドキュメントを含む単一のZIPファイルとして配布されていました。 

1. Aspose.Words for Android via Java 18.9 よりも古いバージョンを使用する場合は、Aspose.Slides.Android.zip のそのバージョンを好みのディレクトリに解凍する必要があります。 
1. 抽出したJarファイルを、ビルドパス設定を使用してアプリケーションに追加します。 
### **Aspose.Slides for Android via Java Jarへの参照を追加**
1. 最新のバージョンの[Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/androidjava)をダウンロードします。
1. aspose-slides-18.9-android.via.java.jarをプロジェクトの*libs/*フォルダーにコピーします。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **MavenリポジトリからのAspose.Slides for Android via Javaのインストール**
1. build.gradleにmavenリポジトリを追加します。 
1. [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) JARを依存関係として追加します。

``` java

 // 1. build.gradleにmavenリポジトリを追加します 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. 'Aspose.Slides for Android via Java' JARを依存関係として追加します

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}

```
## **Aspose.Slides for Android via Javaを使用した最初のアプリケーション**
このセクションでは、Aspose.Slides for Android via Javaの使い始め方を学びます。新しいAndroidプロジェクトをゼロからセットアップし、Aspose.Slides JARへの参照を追加し、ディスクにPPTX形式で保存される新しいPowerPointプレゼンテーションを作成する方法を示します。ここでは、[Android Studio](https://developer.android.com/studio/index.html)を使用して開発し、アプリケーションはAndroidエミュレーターで実行されます。Aspose.Slides for Android via Javaを使用して開始するには、以下のステップバイステップのチュートリアルに従って、Aspose.Slides for Android via Javaを使用するアプリを作成します：

1. [Android Studio](https://developer.android.com/studio/index.html)をダウンロードして、任意の場所にインストールします。
1. Android Studioを実行します。
1. 新しいAndroidアプリケーションプロジェクトを作成します。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. aspose-slides-XX.XX-android.via.java.jarをプロジェクトのlibsフォルダーにコピーします。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. プロジェクトセクションを選択し（ファイルメニューから）、依存関係タブをクリックします。
   1. "+"ボタンをクリックします。ファイル依存関係オプションを選択します。
   1. libsフォルダーからAspose.Slidesライブラリを選択し、OKをクリックします。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. gradleファイルとプロジェクトを同期します（必要な場合）。 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. SDカードにアクセスするには、特別な権限を追加する必要があります。AndroidManifest.xmlファイルをクリックし、XMLビューを選択します。この行をファイルに追加します<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. アプリのコードセクションに戻り、以下のインポートを追加します： 

``` java

 import java.io.File;

import com.aspose.slides.IAutoShape;

import com.aspose.slides.IParagraph;

import com.aspose.slides.IPortion;

import com.aspose.slides.ISlide;

import com.aspose.slides.ITextFrame;

import com.aspose.slides.Presentation;

import com.aspose.slides.SaveFormat;

import com.aspose.slides.ShapeType;

import android.os.Environment; 

```

次に、このコードをonCreateメソッドの本体に挿入して、Aspose.Slidesを使用して新しいPresentationをゼロから作成し、SDカードにPPTX形式で保存します。

``` java

 try

{

    // PPTXを表すPresentationクラスのインスタンス化

    Presentation pres = new Presentation();



    // 最初のスライドにアクセス

    ISlide sld = pres.getSlides().get_Item(0);



    // 長方形型のAutoShapeを追加

    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // 長方形にTextFrameを追加

    ashp.addTextFrame(" ");



    // テキストフレームにアクセス

    ITextFrame txtFrame = ashp.getTextFrame();



    // テキストフレームのためのParagraphオブジェクトを作成

    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // 段落のためのPortionオブジェクトを作成

    IPortion portion = para.getPortions().get_Item(0);



    // テキストを設定

    portion.setText("Aspose TextBox");



    // PPTXをカードに保存

    String sdCardPath = Environment.getExternalStorageDirectory().getPath() + File.separator;

    pres.save(sdCardPath + "Textbox.pptx",SaveFormat.Pptx);

}

catch (Exception e)

{

   e.printStackTrace();

}

```

完全なコードは次のようになります：

![todo:image_alt_text](install-aspose-slides-for-android-via-java_13.png)



1. もう一度アプリケーションを実行します。この時、Aspose.Slidesのコードはバックグラウンドで実行され、SDカードに保存されるドキュメントが生成されます。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. 作成したドキュメントを表示するには、ツールメニューに移動します。Androidを選択し、Android Device Monitorを選択します。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **バージョン管理**
2018年以降、Aspose.Slides for Android via Javaのバージョン管理は、Aspose.Slides for Javaに準拠しています。 