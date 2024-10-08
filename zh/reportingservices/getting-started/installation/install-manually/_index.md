---  
title: 手动安装  
type: docs  
weight: 30  
url: /reportingservices/install-manually/  
---  

{{% alert color="primary" %}}  

仅在计划手动安装 Aspose.Slides for Reporting Services 的情况下，才请遵循这些步骤。在这种情况下，您已下载了包含程序集文件的 ZIP 包。  

{{% /alert %}}  

{{% alert title="注意" color="warning" %}}  

**Aspose.Slides for Reporting Services** 需要在主机上安装 **.NET Framework 3.5**。  

{{% /alert %}}  

### **手动安装**  
以下说明告诉您如何在安装 Microsoft SQL Server Reporting Services 的目录中复制和修改文件：  

1. 找到报告服务器安装目录。   
   Microsoft SQL Server 的根目录通常位于此处：***C:\Program Files\Microsoft SQL Server***  
   
   {{% alert color="primary" %}}  

   **Microsoft SQL Server 2005 和 2008**：机器上可能配置了多个 Microsoft SQL Server 实例，它们可能占用不同的 MSSQL.x 子目录，例如 MSSQL.1、MSSQL.2 等。在继续下一步之前，您必须找到正确的 ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** 目录。  

   {{% /alert %}} 所有下面使用的路径将对此目录称为 <Instance>。  

2. 将 Aspose.Slides.ReportingServices.dll 复制到 **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin** 文件夹。  
   **Aspose.Slides.ReportingServices.zip** 下载包含 **Aspose.Slides.ReportingServices.dll**。 {{% alert color="primary" %}}  

在某些情况下，当您将 DLL 复制到 **ReportServer\bin** 目录时，它可能会与分配给它的显式 NTFS 文件权限一起复制。NTFS 权限会导致 Microsoft SQL Server Reporting Services 在加载 **Aspose.Slides.ReportingServices.dll** 时被拒绝访问。如果发生这种情况，将无法使用新的导出格式。检查并确认正确的 NTFS 权限是否已设置：  

   1. 右键单击 **Aspose.Slides.ReportingServices.dll**。  
   1. 点击 **属性** 并选择 **安全性** 选项卡。  
   1. 删除任何显式分配的 NTFS 权限，仅保留继承的权限。  

{{% /alert %}}  

3. 将 Aspose.Slides for Reporting Services 注册为渲染扩展：  
   1. 打开 *C:\Program   
      Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*。  
   1. 将以下行添加到 <Render> 元素：  

**<Render>**  

``` xml  

   ...  

  <!--从这里开始。-->  

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>  

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>  

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>  

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>  

  <!--到这里结束。-->  

</Render>  

```  

4. 授予 Aspose.Slides for Reporting Services 执行权限：  
   1. 打开 **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**。  
   1. 将以下内容添加为外层第二个 <CodeGroup> 元素中的最后一项（该元素应该是 <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="此代码组授予 MyComputer 代码执行权限。">）。  

**<CodeGroup>**  

``` xml  

...  

  <CodeGroup>  

    ...  

    <!--从这里开始。-->  

    <CodeGroup  

        class="UnionCodeGroup"  

        version="1"  

        PermissionSetName="FullTrust"  

        Name="Aspose.Slides_for_Reporting_Services"  

        Description="此代码组授予 AS4SSRS 程序集完全信任。">  

        <IMembershipCondition  

            class="StrongNameMembershipCondition"  

            version="1"  

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e  

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2  

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744  

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />  

    </CodeGroup>  

    <!--到这里结束。-->  

  </CodeGroup>  

</CodeGroup>  

```  

5. 验证 Aspose.Slides for Reporting Services 是否成功安装：  
   1. 打开报告管理器，并检查报告的可用导出类型列表。  

      {{% alert color="primary" %}} 您可以通过打开一个浏览器（Microsoft Internet Explorer 6.0 或更高版本），并在地址栏中输入报告管理器 URL（默认是 http://< ComputerName >/Reports ）来启动报告管理器。  

      {{% /alert %}}  

1. 在服务器上选择一个报告。  
1. 打开 **选择格式** 列表。  
   您应该看到由 Aspose.Slides for Reporting Services 提供的导出格式列表。  
1. 选择 **PPT – 通过 Aspose.Slides 导出的 PowerPoint 演示文稿**。  

   **Aspose.Slides for Reporting Services 安装成功，新的导出格式可用。**  

![todo:image_alt_text](install-manually_1.png)  

6. 点击 **导出** 链接。  
   报告按所选格式生成，然后发送到客户端，最后在适当的应用程序中打开。在我们的例子中，报告是在 Microsoft PowerPoint 中打开的。  

   **由 Aspose.Slides for Reporting Services 生成的 PPT 报告。**  

![todo:image_alt_text](install-manually_2.png)  

您已成功安装 Aspose.Slides for Reporting Services，并将报告生成作为 Microsoft PowerPoint 演示文稿！  