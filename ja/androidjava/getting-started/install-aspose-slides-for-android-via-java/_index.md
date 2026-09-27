---
title: Aspose.Slides for Android via Java のインストール
type: docs
weight: 90
url: /ja/androidjava/install-aspose-slides-for-android-via-java/
keywords:
- Aspose.Slides のインストール
- Aspose.Slides のダウンロード
- Aspose.Slides の使用
- Aspose.Slides のインストール
- Gradle
- Maven リポジトリ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose の Maven リポジトリから Gradle を使用して Android Studio プロジェクトに Aspose.Slides for Android via Java を追加するか、JAR ファイルを手動で追加します。"
---
## **概要**

この記事では、Aspose.Slides for Android via Java を Android プロジェクトに追加する方法を説明します。推奨される方法は、Gradle に Aspose の Maven リポジトリからライブラリをダウンロードさせることです。JAR ファイルをダウンロードして手動でプロジェクトに追加することもできます。

このライブラリは Maven Central や Google の Maven リポジトリには公開されていません。Aspose の独自リポジトリで `aspose-slides` アーティファクトとして `android.via.java` クラシファイアと共に提供されています。

## **Aspose の Maven リポジトリからインストール**

### **手順 1: リポジトリの追加**

新しい Android Studio プロジェクトは、*settings.gradle.kts* の `dependencyResolutionManagement` ブロック内でリポジトリを宣言し、Gradle はモジュールのビルドファイルが追加したリポジトリを拒否します。2 つ目の `dependencyResolutionManagement` ブロックを貼り付けるのではなく、既存のブロック内の `repositories` ブロックに以下の `maven` 行を追加してください。

```kotlin
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = uri("https://releases.aspose.com/java/repo/") }
    }
}
```

### **手順 2: 依存関係の追加**

アプリモジュールのビルドファイル *app/build.gradle.kts* の `dependencies` ブロックにライブラリを追加します。

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

座標の最後の部分である `android.via.java` は、ライブラリの Android ビルドを選択するクラシファイアです。これがないと、Gradle はアーティファクトを見つけられません。

その後、Gradle ファイルとプロジェクトを同期させ、Gradle がライブラリをダウンロードするようにします。

### **バージョンの選択**

Aspose.Slides for Android via Java はリポジトリのすべてのバージョン向けにビルドされているわけではありません。ビルドは一部の Aspose.Slides for Java バージョンに対してのみ公開されており、Android ビルドが存在しないバージョンは解決できません。[Aspose.Slides for Android via Java ダウンロードページ](https://releases.aspose.com/slides/ja/androidjava/)に記載されているバージョンを選択してください。

### **Groovy ビルドスクリプト**

プロジェクトが Groovy ビルドスクリプトを使用している場合、*settings.gradle* の既存の `dependencyResolutionManagement` ブロック内の `repositories` ブロックに `maven` 行を追加してください。

```groovy
dependencyResolutionManagement {
    repositoriesMode.set(RepositoriesMode.FAIL_ON_PROJECT_REPOS)
    repositories {
        google()
        mavenCentral()
        maven { url = 'https://releases.aspose.com/java/repo/' }
    }
}
```

そして、依存関係を *app/build.gradle* に追加します。

```groovy
dependencies {
    implementation 'com.aspose:aspose-slides:26.9:android.via.java'
}
```

## **JAR ファイルを手動で追加**

Maven リポジトリを使用できない場合は、JAR ファイルをプロジェクトに追加します。

1. バージョンのフォルダーにある [Aspose の Maven リポジトリ](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) から JAR ファイルをダウンロードします。バージョン 26.9 の場合、*26.9* フォルダーに *aspose-slides-26.9-android.via.java.jar* というファイルがあります。
2. ファイルをプロジェクトの *app/libs* フォルダーにコピーします。フォルダーが存在しない場合は作成してください。
3. ファイルを *app/build.gradle.kts* の `dependencies` ブロックに追加し、プロジェクトを同期させます。

```kotlin
dependencies {
    implementation(files("libs/aspose-slides-26.9-android.via.java.jar"))
}
```

## **最初のプレゼンテーションを作成**

プロジェクトの同期が完了したら、[Create Presentations](/slides/ja/androidjava/create-presentation/) に進みます。この最初の例では、スライドにテキスト ボックスを追加し、プレゼンテーションをアプリのプライベートストレージに保存します。これにはストレージ権限は不要です。ライセンスがない場合、Aspose.Slides は保存したすべてのスライドに評価用の透かしを付加します。詳しくは [Licensing](/slides/ja/androidjava/licensing/) を参照してください。

## **バージョニング**

2018 年以降、Aspose.Slides for Android via Java のバージョニングは Aspose.Slides for Java に合わせて行われています。Android ビルドはすべての Java バージョンに対して公開されているわけではありません；[バージョンの選択](#choose-a-version) を参照してください。

## **FAQ**

### Aspose.Slides が正しく統合されているかどうかを確認するには？

プロジェクトをビルドし、空の [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) をインスタンス化して新しい名前で保存します。例外が発生せずにファイルが作成できれば、ライブラリは正常に統合されています。

### 大きなプレゼンテーションを処理する際にメモリ使用量を制限するには？

各 [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスの [dispose](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#dispose--) メソッドを `finally` ブロックで呼び出してリソースを速やかに解放し、同時に処理するプレゼンテーションは1つずつにしてください。これにより、メモリ不足エラーを防ぎ、バッチ処理中の全体的なメモリ使用量を予測可能に保ちます。

### 不要なエクスポート形式を除外して最終的な JAR サイズを縮小できますか？

現在の Aspose.Slides のリリースは単一のモノリシックライブラリとして配布されているため、ビルド時に PDF や SVG など特定のエクスポート機能を無効にすることはできません。