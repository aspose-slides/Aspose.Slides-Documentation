---
title: 宣言
type: docs
weight: 110
url: /ja/net/declaration/
keywords:
- 宣言
- コンポーネント
- フルトラスト パーミッション
- レジストリ設定
- システム ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の信頼要件、権限、およびホスティング制限について学び、サーバー上で PPT、PPTX、ODP を処理するアプリを安全にデプロイできるようにします。"
---
{{% alert color="info" %}} 

すべての Aspose .NET コンポーネントは、特定の操作（たとえばフォントの解析）でレジストリ設定、システム ファイル、仮想ディレクトリ以外の場所に保存されたファイルにアクセスする必要があるため、Full Trust パーミッションセットが必要です。さらに、Aspose .NET コンポーネントはコア .NET システム クラスに基づいており、多くの場合 Full Trust パーミッションセットが必要です。 

{{% /alert %}} 

複数の企業のアプリケーションをホスティングするインターネットサービスプロバイダーは、主に Medium Trust セキュリティレベルを適用します。.NET 2.0 の場合、このセキュリティレベルは次の制約を課します: 

- OleDbPermission は利用できません。これは、データベースにアクセスするために ADO.NET 管理 OLE DB データ プロバイダーを使用できないことを意味します。  
- EventLogPermission は利用できません。これは、Windows イベント ログにアクセスできないことを意味します。  
- ReflectionPermission は利用できません。これは、リフレクションを使用できないことを意味します。  
- RegistryPermission は利用できません。これは、レジストリにアクセスできないことを意味します。  
- WebPermission は制限されています。これは、アプリケーションが <trust> 要素で定義したアドレスまたはアドレス範囲としか通信できないことを意味します。  
- FileIOPermission は制限されています。これは、アプリケーションの仮想ディレクトリ階層内のファイルしかアクセスできないことを意味します。  

{{% alert color="info" %}} 

上記の理由により、Aspose .NET コンポーネントは Full Trust パーミッションセットを付与したサーバーでのみ使用できます。 

{{% /alert %}}