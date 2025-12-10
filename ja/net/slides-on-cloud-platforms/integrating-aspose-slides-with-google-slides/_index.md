---
title: Aspose.Slides と Google Slides の統合
linktitle: Google スライド
type: docs
weight: 50
url: /ja/net/integrating-aspose-slides-with-google-slides/
keywords:
- クラウド プラットフォーム
- クラウド統合
- Google スライド
- Google ドライブ
- Google API
- Google サービス アカウント
- SaaS 統合
- OAuth 2.0
- PPT から PDF へ
- PowerPoint 自動化
- プレゼンテーション処理
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を Google Slides と接続し、プレゼンテーションのインポート、同期、変換を行い、ワークフローを自動化し、PowerPoint と OpenDocument を同一パイプラインで管理します。"
---

## **はじめに**

Aspose.Slides は、[SaaS Integration API](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) を通じて Google Slides と Google Drive との統合を提供します。この統合により .NET アプリケーションは Google Slides プレゼンテーションを変換、編集、ダウンロード、アップロードできるようになります。

## **Google Slides とは？**
[Google Slides](https://workspace.google.com/products/slides/) は Google が開発した無料の Web ベースのプレゼンテーションソフトウェアです。Microsoft PowerPoint に似たスライド作成、編集、共有がオンラインで可能で、リアルタイム共同作業、クラウドストレージをサポートし、インターネットに接続できる任意のデバイスで利用できます。

## **Google API**
Aspose.Slides で Google Slides プレゼンテーションを操作する前に、Google API プロジェクトを作成し、[Google Cloud プロジェクト](https://developers.google.com/workspace/guides/create-project) を作成して対象の API を有効化する必要があります。

次に、Google API へのアクセス方法を選択します。 [Aspose.Slides Google Integration](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) は以下の 2 つの方法をサポートしています。
- `Google Service Account`
- `OAuth 2.0`（ブラウザによるユーザー操作）

### **Google Service Account**
サービスアカウントは、ユーザー操作なしでアプリケーションやサーバーが Google API にプログラム的にアクセスするために使用される特別な Google アカウントです。通常はバックエンドシステムや自動化タスクで使用され、JSON キーファイルで認証され、独自のメールアドレスを持ちます。権限は [Google Cloud IAM](https://cloud.google.com/iam/docs/overview) で個別に付与でき、Google Drive、Sheets、BigQuery などの API への安全な自動アクセスに利用されます。

### **OAuth 2.0**
もう一つの一般的な方法は、ブラウザでのユーザー操作を伴う OAuth 2.0 です。このフローではユーザーが Google のサインインページにリダイレクトされ、アプリへの許可を与えます。許可が得られるとアプリは認可コードを受け取り、これをアクセストークンとリフレッシュトークンに交換します。

アクセストークンは Google API への一時的なアクセスを可能にし、リフレッシュトークンは保存しておくことで、ユーザーが再度ログインすることなく新しいアクセストークンを取得できます。したがって、ブラウザ操作は最初の 1 回だけ必要で、以降の API 呼び出しは完全に自動化できます。この方法は、ユーザーデータ（Gmail、カレンダー、Drive など）へのアクセスが必要なアプリに適しています。

## **コードを書いてみましょう**
最初に、[Aspose.Slides SaaS Integration NuGet パッケージ](https://www.nuget.org/packages/Aspose.Slides.SaaSIntegrations) をプロジェクトに追加します。
```
dotnet add package Aspose.Slides.SaaSIntegrations
```


### **例 1**
以下の例では、Google Drive から Google Slides プレゼンテーションをダウンロードし、ローカルディスクに PDF ファイルとして保存します。認証にはサービスアカウントを使用し、認証情報が記載された JSON ファイルが既にダウンロードされているものとします。
```csharp
// 外部で管理される HttpClient を作成
HttpClient httpClient = new HttpClient();

// サービス アカウント JSON ファイルを使用して認可プロバイダーを作成
IGoogleAuthorizationProvider account = new GoogleServiceAccountAuthProvider(@"service_account_json_file.json", httpClient);

// 認可プロバイダーで Google Slides 統合サービスを初期化
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// Google Drive からファイル ID でプレゼンテーションをロードし、Aspose.Slides の IPresentation インスタンスに格納
using IPresentation pres = await googleSlidesIntegration.LoadPresentationAsync("1A2B3C4D5E6F7G8H9I0J");

// 必要に応じてプレゼンテーションを修正 (例: 2 番目のスライドを削除)
pres.Slides.RemoveAt(1);

// プレゼンテーションをローカルに PDF ファイルとして保存
pres.Save(@"GoogleDriveDownload.pdf", SaveFormat.Pdf);
```


便利なことに、Aspose.Slides SaaS Integration にはユーザーが利用可能なすべてのファイルを一覧取得するメソッドが用意されています。返却されるデータにはファイル名、MIME タイプ、ファイル ID が含まれます。
```csharp
// 提供されたサービスアカウントで利用可能なファイルの一覧を取得
var availableFiles = await googleSlidesIntegration.GetDriveFileInfosAsync();

foreach (GoogleDriveFileInfo googleDriveFileInfo in availableFiles)
{
    Console.WriteLine($"File name: {googleDriveFileInfo.Name}, File ID: {googleDriveFileInfo.Id}, MIME type: {googleDriveFileInfo.MimeType}");
}
```


ファイル ID を取得する別の方法として、Google Slides のウェブアプリでプレゼンテーションを開き、URL に含まれる ID を確認することができます。

例として、次の URL を見てみましょう：
```
https://docs.google.com/presentation/d/1A2B3C4D5E6F7G8H9I0J/edit
```


ファイル ID は次の通りです：
```
1A2B3C4D5E6F7G8H9I0J
```


## **例 2**
次の例では、PowerPoint プレゼンテーションをゼロから作成し、Google Slides 形式で Google Drive にアップロードします。認証には OAuth 2.0 を使用します。
```csharp
// 外部で管理される HttpClient を作成
HttpClient httpClient = new HttpClient();

// クライアント ID とクライアント シークレットを使用した OAuth 認可プロバイダーを作成
IGoogleAuthorizationProvider account = new GoogleOAuthProvider("clientId", "clientSecret", httpClient);

// 認可プロバイダーで Google Slides 統合サービスを初期化
GoogleSlidesIntegration googleSlidesIntegration = new GoogleSlidesIntegration(account, httpClient);

// サンプル プレゼンテーションを作成
using (var presentation = new Presentation())
{
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";
    
    // プレゼンテーションを Google Drive のルートフォルダーに Google Slides 形式で保存
    // Aspose.Slides がサポートする他のエクスポート形式も選択可能です
    var newFileId = await googleSlidesIntegration.SavePresentationAsync(presentation, "New presentation", GoogleSaveFormatType.GoogleSlides);
    Console.WriteLine($"Uploaded file ID: {newFileId}");
}
```


この認証方式をアプリで使用する場合、`interaction with the browser is required` となります。アカウントを選択し、アプリが Google Drive API へのアクセスを許可することを確認する必要があります。これで完了です――この操作は初回実行時にのみ必要です。

### **例 3**
以下の例では、事前に取得したアクセストークンを使用します。`GoogleAccessTokenAuthProvider` は既存の OAuth 2.0 アクセストークンを利用して Google API へのリクエストを認可する `IGoogleAuthorizationProvider` インターフェイスの実装です。OAuth フローを開始または管理するプロバイダーとは異なり、このクラスは呼び出し側が有効なアクセストークンを提供することを前提としています。

このプロバイダーは、アクセストークンがフロントエンドアプリや別サービスなど外部で取得され、バックエンドに渡されるシナリオに適しています。特に、リフレッシュトークンをサーバー側で管理すると同時更新の競合や無効化リスクが生じやすい分散環境で有用です。

この例では、Google Drive 上のファイルを置き換え、名前を更新しつつファイル ID を保持する方法を示します。
```csharp
// リクエストを行うための HTTP クライアントを作成
using HttpClient httpClient = new HttpClient();

// アクセストークンを使用して Google Drive の認証を設定
GoogleAccessTokenAuthProvider accessTokenAuthProvider = new GoogleAccessTokenAuthProvider("access_token");

// 認証と HTTP クライアントを使用して Google Slides/Drive の統合を初期化
GoogleSlidesIntegration googleSlidesIntegration =
    new GoogleSlidesIntegration(accessTokenAuthProvider, httpClient);

// Aspose.Slides を使用してサンプル プレゼンテーションを作成
using (var presentation = new Presentation())
{
    // 最初のスライドに長方形シェイプを追加し、テキストを設定
    var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    shape.TextFrame.Text = "Hello from Google Drive!";

    // 特定の品質とコンプライアンス設定を持つ PDF 保存オプションを定義
    ISaveOptions saveOptions = new PdfOptions()
    {
        JpegQuality = 50,
        Compliance = PdfCompliance.PdfA1b
    };

    // ファイル ID で Google Drive 上の既存ファイルを保存（置換）し、名前を更新して PDF としてエクスポート
    await googleSlidesIntegration.SavePresentationToExistingFileAsync(
        presentation,
        "1A2B3C4D5E6F7G8H9I0J",            // Google Drive 上の既存ファイルの ID
        GoogleSaveFormatType.Pdf,         // 保存したい形式
        saveOptions,           
        "NewFileName.pdf"                 // ファイルに付与する新しい名前
    );
}
```


## **まとめ**
Aspose.Slides は、クラウドベースのワークフローでプレゼンテーションの作成、共有、編集を自動化するための追加ファイル形式の管理をサポートします。

本記事では基本機能を取り上げましたが、サブフォルダーへの保存、既存ファイルの置き換え、Google Drive へのさまざまな形式（Google Slides プレゼンテーションに限らず）でのエクスポートも可能です。

Aspose.Slides SaaS Integration は今後もプレゼンテーション SaaS プラットフォームのサポートを拡充していく予定ですので、更新情報をご確認ください。

## **FAQ**

**この統合を使用するのに Google Workspace アカウントは必要ですか？**  
いいえ。無料の Google アカウントでも、Google Workspace アカウントでも利用できます。必要なアクセス権は Google Drive と Slides の権限に依存します。

**認証方法は Service Account と OAuth 2.0 のどちらを選べばよいですか？**  
ユーザー操作なしでバックエンドや自動化ワークフローを実行する場合は **Service Account** を使用してください。  
特定ユーザーの Google Slides または Drive ファイルにユーザーの同意のもとアクセスする必要がある場合は **OAuth 2.0** を選択してください。

**Google Slides 以外の形式でも作業できますか？**  
はい。Aspose.Slides はプレゼンテーションを PDF、PPTX、HTML などのさまざまな形式に保存でき、Google Drive にアップロードする前に変換できます。

**Google Slides プレゼンテーションのファイル ID はどうやって取得しますか？**  
`GetDriveFileInfosAsync()` メソッドを使用するか、Google Slides のプレゼンテーション URL からコピーしてください。

**Google Drive 上の既存ファイルを置き換えることは可能ですか？**  
はい。`SavePresentationToExistingFileAsync` メソッドを使用すれば、ファイル ID を保持したままファイルを更新できます。

**OAuth 2.0 使用時に毎回ブラウザ操作が必要ですか？**  
いいえ。最初の認証時にだけブラウザ操作が必要です。その後は保存されたリフレッシュトークンにより自動的にアクセスできます。