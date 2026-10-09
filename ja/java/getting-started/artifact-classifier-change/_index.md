---
title: アーティファクト分類子の変更
type: docs
weight: 60
url: /ja/java/artifact-classifier-change/
keywords:
- Aspose.Slides の分類子
- アーティファクト分類子
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
description: "Aspose.Slides for Java は現在、jdk16 の代わりに jdk8 分類子を使用します。変更理由と依存関係の更新方法を確認してください。"
---
## **`jdk16` から `jdk8` へのアーティファクト分類子の変更**

バージョン **26.10** から、公開アーティファクトで使用する分類子を **`jdk16`**（Java 6）から **`jdk8`**（Java 8）へ変更しました。

### **変更点**

| | 以前 | 以後 |
|---|---|---|
| 分類子 | `jdk16` | `jdk8` |
| 最小 Java バージョン | Java 1.6 | Java 8 |

**以前:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**以後:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **変更理由**

内部レビューの結果、価値がなくなり保守の妨げとなっていた古い Java バージョンのサポートを **廃止**することにしました。すべての利用者に対して安全なベースラインとして Java 8 を選択しました。

このため、実際にサポートされる最小バージョンを示すように分類子を更新しました。また、製品が公式に **JDK 8** と呼称される（従来の `1.8` 形式ではない）現在の Oracle 命名規則に合わせました。

### **対応手順**

1. 依存関係宣言で分類子を `jdk16` から `jdk8` に **更新** してください。

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

2. **ランタイム環境** が Java 8 以上であることを確認してください。

3. 旧分類子を固定している **ロックファイル** や依存キャッシュを **リフレッシュ** してください。

### **マイグレーションノート: jdk16 と jdk8**

バージョン 26.10 以降、jdk16 と jdk8 の両分類子は Java 8 互換の JAR を提供します（ソース/ターゲット互換性は Java 8 に設定）。

- `jdk16` → 後方互換性のために継続的に公開（既存統合向け）。
- `jdk8` → Java 8 環境向けの新しい推奨分類子として導入。

⚠️ 注意: この二重公開フェーズは 2027 年 3 月 31 日に終了する予定です。以降は jdk16 分類子が廃止され、jdk8 のみがサポートされます。

### **互換性に関する注意事項**

- `jdk16` 分類子は **2027 年 3 月 31 日以降は公開されません**。
- まだ Java 1.6 のサポートが必要な場合は、移行できるまで前のメジャーバージョン系統を使用し続けてください。

### **サポートが必要ですか？**

移行中に問題が発生した場合は、[Aspose サポート](https://forum.aspose.com/)までお問い合わせください。