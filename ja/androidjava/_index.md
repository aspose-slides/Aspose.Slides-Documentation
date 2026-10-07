---
title: Aspose.Slides for Android via Java
second_title: Aspose.Slides for Android
type: docs
weight: 40
url: /ja/androidjava/
keywords:
- ドキュメント
- プレゼンテーション処理
- プレゼンテーション変換
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "ここから開始: Aspose.Slides for Android via Java をアプリに追加し、最初のプレゼンテーションを作成し、一般的なタスク、API リファレンス、サポートのガイドを見つけましょう。"
is_root: true
---
<img src="home_1.png" alt="Java を介した Android 用 Aspose.Slides" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Android via Java は、Microsoft PowerPoint を使用せずに Android アプリケーションで PowerPoint および OpenDocument プレゼンテーションの作成、読み取り、編集、変換を行うクラス ライブラリです。

マクロ対応やテンプレートバリアントを含む PPT、PPTX、PPS、POT、ODP を読み込み・保存でき、PDF、XPS、HTML、SVG、TIFF、Markdown、画像へエクスポートします。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始する</b></p>
<hr>
<p>はじめに</p>
<ul>
<li><a href="/slides/ja/androidjava/install-aspose-slides-for-android-via-java/">インストール</a></li>
<li><a href="/slides/ja/androidjava/create-presentation/">最初のプレゼンテーションを作成する</a></li>
<li><a href="/slides/ja/androidjava/getting-started/">はじめにガイド</a></li>
</ul>
<p>評価</p>
<ul>
<li><a href="/slides/ja/androidjava/supported-file-formats/">サポート対象ファイル形式</a></li>
<li><a href="/slides/ja/androidjava/evaluate-aspose-slides/">試用版の制限</a></li>
<li><a href="/slides/ja/androidjava/licensing/">ライセンス</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides で構築</b></p>
<hr>
<p>一般的なタスク</p>
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
<li><a href="/slides/ja/androidjava/merge-presentation/">プレゼンテーションを結合</a></li>
</ul>
<p>例</p>
<ul>
<li><a href="/slides/ja/androidjava/examples/">スライド要素別の例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>リファレンスとサポート</b></p>
<hr>
<p>リファレンス</p>
<ul>
<li><a href="https://reference.aspose.com/slides/androidjava/">API リファレンス</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/release-notes/">リリースノート</a></li>
<li><a href="/slides/ja/androidjava/known-issues/">既知の問題</a></li>
<li><a href="https://products.aspose.com/slides/android-java/">製品ページ</a></li>
<li><a href="https://releases.aspose.com/slides/androidjava/">ダウンロード</a></li>
</ul>
<p>サポート</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">無料サポートフォーラム</a></li>
<li><a href="https://helpdesk.aspose.com/">有料サポートヘルプデスク</a></li>
</ul>
</div>
</div>

------

## **最初のプレゼンテーション**

このライブラリは Aspose の Maven リポジトリから取得できます。新しい Android Studio プロジェクトには既に *settings.gradle.kts* に `dependencyResolutionManagement` ブロックが含まれています。2 つ目のブロックを貼り付けるのではなく、以下に示す `maven` 行をその中の `repositories` ブロックに追加してください：

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

次に、ライブラリを *app/build.gradle.kts* に追加し、プロジェクトを同期させます：

```kotlin
dependencies {
    implementation("com.aspose:aspose-slides:26.9:android.via.java")
}
```

[インストール](/slides/ja/androidjava/install-aspose-slides-for-android-via-java/) は Groovy ビルド スクリプト、手動 JAR ファイル、バージョン選択方法について説明しています。最初のプレゼンテーションのコードは [プレゼンテーションの作成](/slides/ja/androidjava/create-presentation/) にあります。テキスト ボックスをスライドに追加し、プレゼンテーションをアプリのストレージに保存します。このサンプルは APK にコンパイルされ構築されていますが、デバイス上では実行されていません。ライセンスがない場合、保存されたプレゼンテーションには評価用の透かしが付加されます — 詳細は [ライセンス](/slides/ja/androidjava/licensing/) を参照してください。