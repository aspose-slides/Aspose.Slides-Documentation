---
title: セキュリティマネージャーの要件
type: docs
weight: 190
url: /ja/java/declaration/
keywords:
- セキュリティマネージャー
- セキュリティポリシー
- AllPermission
- パーミッション
- サンドボックス
- JDK 24
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Java 23 以前で Aspose.Slides for Java とそれを呼び出すコードが必要とする Security Manager のパーミッションと、Java 24 以降では設定するものが何もない理由"
---
## **概要**

Java Security Manager は、セキュリティ ポリシーに基づいてコードができることを制限します。Java 17 では削除予定として非推奨にされ (JEP 411)、Java 24 では完全に無効化されました (JEP 486)。本記事では、Security Manager が有効なままアプリケーションを実行する場合に Aspose.Slides for Java が必要とする設定について説明します。デフォルトでは Security Manager は有効になっていないため、設定が必要になることはありません。

## **Java 23 およびそれ以前**

Security Manager が有効な場合、セキュリティ ポリシーは Aspose.Slides の JAR ファイルとそれを呼び出すアプリケーションコードの両方に以下のパーミッションを付与する必要があります。

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides がシステムプロパティを読み取ります。
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides がフォント ファイルやその他のファイルを読み取ります。
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides がオペレーティングシステムのプログラムを起動します。例として Windows の `reg` や Linux の `fc-match` があります。
- `java.io.FilePermission` with the `write` action for the folders where your application saves files: アプリケーションがファイルを保存するフォルダーに対して `write` アクションを持つ `java.io.FilePermission` を付与します。

JAR ファイルだけにパーミッションを付与しても不十分です。Aspose.Slides を呼び出すコードにも同様のパーミッションが必要です。`java.security.AllPermission` を両方に付与する方法も有効です。

システムプロパティの読み取りやプログラムの起動権限がない場合、Aspose.Slides は最初の使用時に失敗します。`[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/)` オブジェクトの作成時に `ExceptionInInitializerError` がスローされます。また、フォント ファイルへの読み取り権限がないと、プレゼンテーションを PDF として保存しようとした際に「Cannot find any fonts installed on the system」というエラーで失敗します。

## **Java 24 以降**

Java 24 以降では Security Manager を有効にできないため、付与すべきパーミッションは存在しません。Aspose.Slides はアプリケーションを実行しているアカウントの権限で動作します。アプリケーションのアクセス範囲を制限したい場合、OpenJDK プロジェクトはコンテナやハイパーバイザー、OS のサンドボックス機能など、JDK 外部の技術を使用することを推奨しています。[JEP 486](https://openjdk.org/jeps/486) を参照してください。

## **FAQ**

**制限の厳しい Security Manager ポリシーの下でアプリケーションを実行する環境で Aspose.Slides を使用できますか？**

上記のパーミッションが Aspose.Slides とそれを呼び出すコードの両方に付与されている場合に限り使用できます。これらのパーミッションにはすべてのファイルの読み取りと任意のプログラムの起動が含まれます。