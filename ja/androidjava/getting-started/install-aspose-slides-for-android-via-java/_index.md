---
title: Aspose.Slides for Android via Java のインストール
type: docs
weight: 90
url: /ja/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- Aspose.Slides のインストール
- Aspose.Slides のダウンロード
- Aspose.Slides の使用
- Aspose.Slides のインストール手順
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android をすぐにインストールできます。ステップバイステップのガイド、システム要件、Java コードサンプル — 今日から PowerPoint プレゼンテーションの作成を始めましょう！"
---

## **インストール**
以前、Aspose.Slides for Android via Java は JAR ファイル、デモ、および製品ドキュメントを含む単一の ZIP ファイルとして配布されていました。

1. Aspose.Words for Android via Java 18.9 より古いバージョンを使用したい場合は、Aspose.Slides.Android.zip を好みのディレクトリに解凍する必要があります。 
1. ビルド パス設定を使用して、抽出した Jar ファイルをアプリケーションに追加します。 
### **Aspose.Slides for Android via Java Jar への参照を追加**
1. 最新バージョンの[Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/androidjava) をダウンロードします 
1. aspose‑slides‑18.9‑android.via.java.jar をプロジェクトの*libs/*フォルダーにコピーします

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)
### **Maven リポジトリから Aspose.Slides for Android via Java をインストール**
1. build.gradle に Maven リポジトリを追加します。 
1. [Aspose.Slides for Android via Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) の JAR を依存関係として追加します。
``` java

 // 1. build.gradle に Maven リポジトリを追加します 

repositories {

    mavenCentral()

    maven { url "https://releases.aspose.com/java/repo/" }

}

// 2. 'Aspose.Slides for Android via Java' JAR を依存関係として追加します

dependencies {

    ...

    ...

    compile (group: 'com.aspose', name: 'aspose-slides', version: 'XX.XX', classifier: 'android.via.java')

}
```

## **Aspose.Slides for Android via Java を使用した最初のアプリケーション**
このセクションでは、Aspose.Slides for Android via Java の入門方法を学びます。新しい Android プロジェクトをスクラッチでセットアップし、Aspose.Slides JAR への参照を追加し、PPTX 形式でディスクに保存される新しい PowerPoint プレゼンテーションを作成する方法を示します。例では[Android Studio](https://developer.android.com/studio/index.html) を使用して開発し、Android エミュレーター上でアプリケーションを実行します。Aspose.Slides for Android via Java の使用を開始するには、次のステップバイステップ チュートリアルに従ってアプリを作成してください。

1. [Android Studio](https://developer.android.com/studio/index.html) をダウンロードし、任意の場所にインストールします。 
1. Android Studio を起動します。 
1. 新しい Android アプリケーション プロジェクトを作成します。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_3.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_4.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_5.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_6.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_7.png)





1. aspose‑slides‑XX.XX‑android.via.java.jar をプロジェクトの libs/ フォルダーにコピーします

![todo:image_alt_text](install-aspose-slides-for-android-via-java_1.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_2.png)




1. ファイル メニューから Project Section を選択し、Dependencies タブをクリックします。  
   1. 「+」ボタンをクリックし、ファイル依存関係オプションを選択します。  
   1. libs フォルダーから Aspose.Slides ライブラリを選択し、OK をクリックします。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_10.png)




1. 必要に応じて Gradle ファイルとプロジェクトを同期します。 

![todo:image_alt_text](install-aspose-slides-for-android-via-java_11.png)





1. SD カードにアクセスするには特別な権限が必要です。AndroidManifest.xml ファイルを開き XML ビューを選択し、次の行をファイルに追加します <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />



![todo:image_alt_text](install-aspose-slides-for-android-via-java_12.png)




1. アプリのコード セクションに戻り、次のインポートを追加します： 
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


Now, insert this code in the body of the onCreate method to create a new Presentation from scratch using Aspose.Slides and save it to the SDCard in PPTX format.
``` java
 try

{

    // PPTX を表す Presentation クラスのインスタンス化
    Presentation pres = new Presentation();



    // 最初のスライドにアクセス
    ISlide sld = pres.getSlides().get_Item(0);



    // 矩形タイプの AutoShape を追加
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);



    // 矩形に TextFrame を追加
    ashp.addTextFrame(" ");



    // テキストフレームにアクセス
    ITextFrame txtFrame = ashp.getTextFrame();



    // テキストフレーム用の Paragraph オブジェクトを作成
    IParagraph para = txtFrame.getParagraphs().get_Item(0);



    // Paragraph 用の Portion オブジェクトを作成
    IPortion portion = para.getPortions().get_Item(0);



    // テキストを設定
    portion.setText("Aspose TextBox");



    // PPTX をカードに保存
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



1. アプリケーションを再度実行します。このとき Aspose.Slides のコードがバックグラウンドで実行され、SD カードに保存されるドキュメントが生成されます。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_14.png)

![todo:image_alt_text](install-aspose-slides-for-android-via-java_15.jpg)

1. 作成されたドキュメントを表示するには、Tools メニューに移動し、Android を選択してから Android Device Monitor を選択します。

![todo:image_alt_text](install-aspose-slides-for-android-via-java_16.jpg)




![todo:image_alt_text](install-aspose-slides-for-android-via-java_17.jpg)
## **バージョン管理**
2018 年以降、Aspose.Slides for Android via Java のバージョン管理は Aspose.Slides for Java に準拠しています。

## **FAQ**

**Aspose.Slides が正しく統合されているかどうかを確認する方法は？**

プロジェクトをビルドし、空の[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) をインスタンス化して新しい名前で保存します。例外が発生せずにファイルが作成されれば、ライブラリは正常に統合されています。

**大規模なプレゼンテーションを処理する際のメモリ消費を抑える方法は？**

必要最低限の JVM メモリ上限だけを設定し、`finally` ブロック内で各[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) インスタンスを確実に閉じてキャッシュを速やかに解放します。これによりメモリ不足エラーを防ぎ、バッチ処理中のメモリ使用量を予測可能に保ちます。

**不要なエクスポート形式を除外して最終的な JAR サイズを削減できるか？**

現在の Aspose.Slides リリースは単一のモノリシック ライブラリとして提供されているため、ビルド時に PDF や SVG など特定のエクスポーターを無効化することはできません。