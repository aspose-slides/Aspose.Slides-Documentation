---
title: 宣言
type: docs
weight: 60
url: /ja/java/declaration/
keywords:
- 宣言
- コンポーネント
- Full Trust 権限
- レジストリ設定
- システムファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java の信頼要件、権限、およびホスティング制限について学び、サーバー上で PPT、PPTX、ODP を処理するアプリを安全に展開できるようにしましょう。"
---
{{% alert color="info" %}} 

すべての Aspose Java コンポーネントは Full Trust 権限セットが必要です。その理由は、Aspose Java コンポーネントはフォントの解析などの特定の操作のために、レジストリ設定や仮想ディレクトリ以外のシステムファイルにアクセスする必要があるためです。さらに、Aspose Java コンポーネントはコア Java システムクラスに基づいており、多くの場合に Full Trust 権限セットが必要です。 

{{% /alert %}} 

異なる企業の複数のアプリケーションをホストするインターネットサービスプロバイダーは、主に Medium Trust セキュリティレベルを適用しています： 

- OleDbPermission は利用できません。これは、データベースにアクセスするための ADO.NET 管理 OLE DB データプロバイダーを使用できないことを意味します。  
- EventLogPermission は利用できません。これは、Windows イベントログにアクセスできないことを意味します。  
- ReflectionPermission は利用できません。これは、リフレクションを使用できないことを意味します。  
- RegistryPermission は利用できません。これは、レジストリにアクセスできないことを意味します。  
- WebPermission は制限されています。これは、アプリケーションが <trust> 要素で定義したアドレスまたはアドレス範囲とだけ通信できることを意味します。  
- FileIOPermission は制限されています。これは、アプリケーションの仮想ディレクトリ階層内のファイルのみアクセスできることを意味します。  

{{% alert color="info" %}} 

上記の理由により、Full Trust 以外の権限セットを付与するサーバー上では Aspose Java コンポーネントを使用できません。 

{{% /alert %}}