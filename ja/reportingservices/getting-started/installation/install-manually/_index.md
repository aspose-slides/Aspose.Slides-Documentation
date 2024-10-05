---
title: 手動インストール
type: docs
weight: 30
url: /reportingservices/install-manually/
---

{{% alert color="primary" %}} 

手動でAspose.Slides for Reporting Servicesをインストールする予定がある場合にのみ、これらの手順に従ってください。この場合、アセンブリファイルを含むZIPパッケージをダウンロードしました。 

{{% /alert %}} 

{{% alert title="注意" color="warning" %}} 

**Aspose.Slides for Reporting Services**は、ホストマシンに**.NET Framework 3.5**のインストールを必要とします。 

{{% /alert %}}

### **手動インストール**
これらの手順では、Microsoft SQL Server Reporting Servicesがインストールされているディレクトリ内のファイルをコピーおよび変更する方法を示します：

1. レポートサーバーのインストールディレクトリを探します。
   Microsoft SQL Serverのルートディレクトリは通常ここにあります：***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 

   **Microsoft SQL Server 2005および2008**：マシン上に複数のMicrosoft SQL Serverインスタンスが構成されている可能性があり、異なるMSSQL.xサブディレクトリ（例：MSSQL.1、MSSQL.2など）を占有しているかもしれません。次のステップに進む前に、正しい***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer***ディレクトリを見つける必要があります。
   
   {{% /alert %}} 以下で使用されるすべてのパスは、このディレクトリを<Instance>として参照します。 

2. Aspose.Slides.ReportingServices.dllを**C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**フォルダにコピーします。
   **Aspose.Slides.ReportingServices.zip**のダウンロードには**Aspose.Slides.ReportingServices.dll**が含まれています。 {{% alert color="primary" %}} 

DLLを**ReportServer\bin**ディレクトリにコピーした場合、明示的に割り当てられたNTFSファイル権限とともにコピーされることがあるので注意してください。NTFS権限により、**Aspose.Slides.ReportingServices.dll**の読み込み時にMicrosoft SQL Server Reporting Servicesがアクセスを拒否されることがあります。これが発生した場合、新しいエクスポート形式は利用できなくなります。正しいNTFS権限が設定されていることを確認してください：

   1. **Aspose.Slides.ReportingServices.dll**を右クリックします。
   1. **プロパティ**をクリックし、**セキュリティ**タブを選択します。
   1. 明示的に割り当てられたNTFS権限を削除し、継承された権限のみを残します。

{{% /alert %}}

3. Aspose.Slides for Reporting Servicesをレンダリング拡張機能として登録します：
   1. *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*を開きます。
   1. <Render>要素に以下の行を追加します：

**<Render>**

``` xml

   ...

  <!--ここから開始します。-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--ここで終了します。-->

</Render>

``` 

4. Aspose.Slides for Reporting Servicesに実行権限を付与します：
   1. **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**を開きます。
   1. 以下を第2層目の<CodeGroup>要素の最後の項目として追加します（これは<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="このコードグループはMyComputerコード実行権限を付与します。">であるべきです）。

**<CodeGroup>**

``` xml

...

  <CodeGroup>

    ...

    <!--ここから開始します。-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="このコードグループはAS4SSRSアセンブリにフルトラストを付与します。">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--ここで終了します。-->

  </CodeGroup>

</CodeGroup>

``` 

5. Aspose.Slides for Reporting Servicesが正常にインストールされたことを確認します：
   1. レポートマネージャーを開き、レポートの利用可能なエクスポートタイプのリストを確認します。 
   
      {{% alert color="primary" %}} レポートマネージャーは、ブラウザ（Microsoft Internet Explorer 6.0以上）を開いてアドレスバーにレポートマネージャーのURLを入力することで起動できます（デフォルトではhttp://< ComputerName >/Reportsです）。 
   
      {{% /alert %}}

1. サーバー上のレポートを選択します。
1. **形式を選択**リストを開きます。
   Aspose.Slides for Reporting Servicesが提供するエクスポート形式のリストが表示されるはずです。 
1. **PPT – Aspose.Slidesを介したPowerPointプレゼンテーション**を選択します。 

   **Aspose.Slides for Reporting Servicesが正常にインストールされ、新しいエクスポート形式が利用可能です。** 

![todo:image_alt_text](install-manually_1.png)

6. **エクスポート**リンクをクリックします。
   レポートが選択した形式で生成され、クライアントに送信され、その後適切なアプリケーションで開かれます。私たちの場合、レポートはMicrosoft PowerPointで開かれました。 

   **Aspose.Slides for Reporting Servicesによって生成されたPPTレポート。** 

![todo:image_alt_text](install-manually_2.png)

Aspose.Slides for Reporting Servicesを正常にインストールし、Microsoft PowerPointプレゼンテーションとしてレポートを生成しました！ 