---
title: 宣言
type: docs
weight: 60
url: /ja/java/artifact-classifier-change/
keywords:
- Aspose.Slides の分類子
- アーティファクト クラシファイア
- Aspose.Slides の使用
- Aspose.Slides のインストール
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java は現在、jdk16 の代わりに jdk8 クラシファイアを使用しています。その理由と依存関係の更新方法をご覧ください。"
---
## **`jdk16` から `jdk8` へのアーティファクト クラシファイアの変更**

バージョン **26.10** から、公開されたアーティファクトで使用されるクラシファイアを **`jdk16`**（Java 6）から **`jdk8`**（Java 8）に変更しました。

### **変更点**

| | 変更前 | 変更後 |
|---|---|---|
| クラシファイア | `jdk16` | `jdk8` |
| 最小 Java バージョン | Java 1.6 | Java 8 |

**変更前:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**変更後:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **この変更を行った理由**

内部レビューの結果、価値がなく、保守を妨げていた古い Java バージョンの **サポートを終了する**ことに決定しました。すべての利用者に対する新しい安全なベースラインとして Java 8 を選択しました。

この一環として、実際にサポートされる最小バージョンを反映するようクラシファイアを更新しました。また、製品が公式に **JDK 8** と呼ばれる（従来の `1.8` 形式ではなく）現在の Oracle の命名規則に合わせました。

### **実行すべきこと**

1. **クラシファイアを更新** してください。依存関係宣言で `jdk16` から `jdk8` に変更します。

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

2. **ランタイム環境を確認** してください。Java 8 以上であることを確認します。

3. **ロックファイル** や古いクラシファイアを固定している依存関係キャッシュを更新してください。

### **移行メモ: jdk16 と jdk8**

バージョン 26.10 から、jdk16 と jdk8 の両方のクラシファイアは Java 8 互換の JAR を提供します（ソース/ターゲットの互換性が Java 8 に設定されています）。

- `jdk16` → 互換性保持のため（既存の統合）引き続き公開されます。
- `jdk8` → Java 8 環境向けの新しい推奨クラシファイアとして導入されました。

⚠️ 注意: この二重公開フェーズは **2027年3月31日** に終了する予定です。終了後、jdk16 クラシファイアは廃止され、jdk8 のみがサポートされます。

### **互換性に関する注意**

- `jdk16` クラシファイアは **2027年3月31日** 以降 **公開されません**。
- まだ Java 1.6 のサポートが必要な場合は、移行できるまで前のメジャーバージョン系統を使用し続けてください。

### **ヘルプが必要ですか？**

移行中に問題が発生した場合は、[Aspose サポート](https://forum.aspose.com/) にお問い合わせください。