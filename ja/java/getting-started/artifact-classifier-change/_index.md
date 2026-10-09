---
title: 宣言
type: docs
weight: 60
url: /ja/java/artifact-classifier-change/
keywords:
- Aspose.Slides の分類子
- アーティファクト分類子
- Aspose.Slides を使用
- Aspose.Slides のインストール
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java は現在、jdk16 の代わりに jdk8 クラスifier を使用しています。理由と依存関係の更新方法をご覧ください。"
---
## アーティファクト クラスifier の変更（`jdk16` から `jdk8` へ）

バージョン **26.10** から、公開されているアーティファクトで使用するクラスifier を **`jdk16`** (Java 6) から **`jdk8`** (Java 8) に変更しました。

### 変更点

| | Before | After |
|---|---|---|
| クラスifier | `jdk16` | `jdk8` |
| 最小 Java バージョン | Java 1.6 | Java 8 |

**変更前:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**変更後:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### この変更を行った理由

内部レビューの結果、価値を提供しなくなった古い Java バージョンのサポートを **廃止** し、メンテナンスを妨げていることが判明したため、サポートを終了することにしました。すべての利用者に対する安全なベースラインとして Java 8 を新たに選定しました。

このため、クラスifier を実際の最小サポートバージョンに合わせて更新しました。また、Oracle の現在の命名規則に合わせ、製品は公式に **JDK 8** と呼ばれるようになり（従来の `1.8` 形式ではなく）ました。

### 実行すべきこと

1. 依存関係宣言でクラスifier を `jdk16` から `jdk8` に **更新** してください。

   **Maven:**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. 実行環境が Java 8 以上であることを **確認** してください。

3. 古いクラスifier を固定しているロックファイルや依存関係キャッシュを **更新** してください。

### 移行に関する注意: jdk16 と jdk8

バージョン 26.10 以降、`jdk16` と `jdk8` の両クラスifier が Java 8 互換の JAR（ソース/ターゲット互換性を Java 8 に設定）を提供します。

 - `jdk16` → 後方互換性のために引き続き公開されます（既存の統合）。
 - `jdk8` → Java 8 環境向けの新しい推奨クラスifier として導入されました。

⚠️ 注意: この二重配信フェーズは **2027年3月31日** に終了する予定です。以降、`jdk16` クラスifier は廃止され、`jdk8` のみがサポートされます。

### 互換性に関する注意事項

- `jdk16` クラスifier は **2027年3月31日** 以降 **公開されなくなります**。
- Java 1.6 のサポートがまだ必要な場合は、移行できるまで前のメジャーバージョンを使用し続けてください。

### サポートが必要ですか？

移行中に問題が発生した場合は、[Aspose support](https://forum.aspose.com/) へお問い合わせください。