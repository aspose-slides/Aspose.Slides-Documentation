---
title: Android 用 Java の Aspose.Slides
second_title: Android 用 Aspose.Slides
type: docs
weight: 40
url: /ja/androidjava/
keywords:
- ドキュメンテーション
- プレゼンテーション処理
- プレゼンテーション変換
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "ここから始めましょう: アプリに Aspose.Slides for Android via Java を追加し、最初のプレゼンテーションを作成し、一般的なタスクのガイド、API リファレンス、サポート情報を見つけてください。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Android via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java は、Microsoft PowerPoint を使用せずに、Android アプリケーションで PowerPoint および OpenDocument のプレゼンテーションを作成、読み取り、編集、変換するためのクラス ライブラリです。

マクロ対応やテンプレート バリアントを含む PPT、PPTX、PPS、POT、ODP をロードおよび保存でき、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>はじめに</b></p>
<hr>
<p>はじめに</p>
<ul>
<li><a href="/slides/ja/androidjava/install-aspose-slides-for-android-via-java/">インストール</a></li>
<li><a href="/slides/ja/androidjava/create-presentation/">最初のプレゼンテーションを作成</a></li>
<li><a href="/slides/ja/androidjava/getting-started/">はじめにガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/androidjava/supported-file-formats/">サポートされているファイル形式</a></li>
<li><a href="/slides/ja/androidjava/evaluate-aspose-slides/">体験版の制限</a></li>
<li><a href="/slides/ja/androidjava/licensing/">ライセンス情報</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>よくあるタスク</p>
<ul>
<li><a href="/slides/ja/androidjava/open-presentation/">プレゼンテーションを開く</a></li>
<li><a href="/slides/ja/androidjava/save-presentation/">プレゼンテーションを保存</a></li>
<li><a href="/slides/ja/androidjava/convert-powerpoint-to-pdf/">PDF に変換</a></li>
<li><a href="/slides/ja/androidjava/convert-slide/">スライドを画像としてレンダリング</a></li>
<li><a href="/slides/ja/androidjava/manage-text/">テキストと図形を編集</a></li>
</ul>
<p>Slides ワークフロー</p>
<ul>
<li><a href="/slides/ja/androidjava/powerpoint-charts/">チャート</a></li>
<li><a href="/slides/ja/androidjava/powerpoint-animation/">アニメーション</a></li>
<li><a href="/slides/ja/androidjava/manage-media-files/">オーディオとビデオ</a></li>
<li><a href="/slides/ja/androidjava/presentation-design/">スライド デザイン</a></li>
<li><a href="/slides/ja/androidjava/merge-presentation/">プレゼンテーションの結合</a></li>
</ul>
<p>サンプル</p>
<ul>
<li><a href="/slides/ja/androidjava/examples/">スライド要素別サンプル</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンス と サポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/ja/androidjava/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/ja/androidjava/release-notes/">リリース ノート</a></li>
<li><a href="/slides/ja/androidjava/known-issues/">既知の問題</a></li>
<li><a href="https://releases.aspose.com/slides/ja/androidjava/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ja/11">無料サポート フォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポート デスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

このライブラリは Aspose の Maven リポジトリから取得します。新しい Android Studio プロジェクトにはすでに *settings.gradle.kts* に `dependencyResolutionManagement` ブロックが含まれています。以下に示す `maven` 行をその中の `repositories` ブロックに追加してください。別のブロックを貼り付けないでください。

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

次に、*app/build.gradle.kts* にライブラリを追加し、プロジェクトを同期します。

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[インストール](/slides/ja/androidjava/install-aspose-slides-for-android-via-java/) では、Groovy ビルド スクリプト、手動 JAR ファイル、バージョンの選択方法について説明しています。最初のプレゼンテーションのコードは [プレゼンテーション作成](/slides/ja/androidjava/create-presentation/) にあります。スライドにテキスト ボックスを追加し、プレゼンテーションをアプリのストレージに保存します。このサンプルはコンパイルされ APK にビルドされていますが、デバイス上では実行されていません。ライセンスがない場合、保存されたプレゼンテーションには評価用の透かしが付加されます — 詳細は [ライセンス情報](/slides/ja/androidjava/licensing/) をご覧ください。