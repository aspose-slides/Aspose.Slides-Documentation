---
title: Manuel Kurulum
type: docs
weight: 30
url: /tr/reportingservices/install-manually/
---
{{% alert color="primary" %}} 

Bu adımları yalnızca Aspose.Slides for Reporting Services'i manuel olarak kurmayı planlıyorsanız izleyin. Bu durumda, derleme dosyalarını içeren ZIP paketini indirmiş olmalısınız. 

{{% /alert %}} 

{{% alert title="Not" color="warning" %}} 

**Aspose.Slides for Reporting Services**, ana bilgisayar makinesinde **.NET Framework 3.5** kurulmasını ister. 

{{% /alert %}}

### **Manuel Kurulum**
Bu talimatlar, Microsoft SQL Server Reporting Services'in kurulu olduğu klasörde dosyaları nasıl kopyalayacağınızı ve değiştireceğinizi gösterir:

1. Report Server kurulum dizinini bulun.  
   Microsoft SQL Server’ın kök dizini genellikle burada bulunur: ***C:\Program Files\Microsoft SQL Server***  

   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 ve 2008**: Makinede birden fazla Microsoft SQL Server örneği yapılandırılmış olabilir ve bu örnekler MSSQL.1, MSSQL.2 gibi farklı MSSQL.x alt dizinlerinde bulunabilir. Sonraki adıma geçmeden önce doğru ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer*** dizinini bulmalısınız.  
   
   {{% /alert %}} Aşağıda kullanılan tüm yollar bu dizini <Instance> olarak referans alacaktır. 

2. Aspose.Slides.ReportingServices.dll dosyasını **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin** klasörüne kopyalayın.  
   **Aspose.Slides.ReportingServices.zip** indirmesi, **Aspose.Slides.ReportingServices.dll** dosyasını içerir. {{% alert color="primary" %}} 

   Bazı durumlarda, DLL'i **ReportServer\bin** dizinine kopyaladığınızda, ona atanmış özel NTFS dosya izinleriyle birlikte kopyalanabilir. NTFS izinleri, Microsoft SQL Server Reporting Services'in **Aspose.Slides.ReportingServices.dll** dosyasını yüklerken erişimini engelleyebilir. Bu durumda yeni dışa aktarma formatları kullanılamaz. Doğru NTFS izinlerinin bulunduğunu kontrol edin ve doğrulayın:

   1. **Aspose.Slides.ReportingServices.dll** üzerine sağ tıklayın.  
   2. **Properties** (Özellikler) seçin ve **Security** (Güvenlik) sekmesine gidin.  
   3. Açıkça atanmış NTFS izinlerini kaldırın ve yalnızca kalıtılan izinlerin kalmasını sağlayın.  

   {{% /alert %}}

3. Aspose.Slides for Reporting Services'i bir render uzantısı olarak kaydedin:  
   1. *C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config* dosyasını açın.  
   2. <Render> öğesine şu satırları ekleyin:  

**<Render>**

``` xml

   ...

  <!--Buradan başlayın.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Buradan sonlandırın.-->

</Render>



```

4. Aspose.Slides for Reporting Services'in çalıştırma izni olsun:  
   1. **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config** dosyasını açın.  
   2. Aşağıdakini, ikinci dış <CodeGroup> öğesinin ( <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. "> olması gerekir) son öğesi olarak ekleyin.  

**<CodeGroup>**

``` xml



...

  <CodeGroup>

    ...

    <!--Buradan başlayın.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="This code group grants full trust to the AS4SSRS assembly.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Buradan sonlandırın.-->

  </CodeGroup>

</CodeGroup>



```

5. Aspose.Slides for Reporting Services'in başarıyla kurulduğunu doğrulayın:  
   1. Report Manager'ı açın ve bir rapor için mevcut dışa aktarma türleri listesini kontrol edin.  

      {{% alert color="primary" %}} Report Manager'ı başlatmak için bir tarayıcı (Microsoft Internet Explorer 6.0 veya daha yenisi) açın ve adres çubuğuna Report Manager URL'sini girin (varsayılan olarak http://< ComputerName >/Reports ).  
   
      {{% /alert %}}

   1. Sunucudaki bir raporu seçin.  
   1. **Select Format** (Biçim Seç) listesini açın.  
      Aspose.Slides for Reporting Services tarafından sağlanan dışa aktarma formatları listesini görmelisiniz.  
   1. **PPT – PowerPoint Presentation via Aspose.Slides** seçeneğini seçin.  

   **Aspose.Slides for Reporting Services başarıyla yüklendi ve yeni dışa aktarma formatları kullanılabilir.**  

![todo:image_alt_text](install-manually_1.png)




6. **Export** (Dışa Aktar) bağlantısına tıklayın.  
   Rapor seçilen formatta oluşturulur, istemciye gönderilir ve ardından uygun bir uygulamada açılır. Bizim örneğimizde rapor Microsoft PowerPoint'te açıldı.  

   **Aspose.Slides for Reporting Services tarafından oluşturulan bir PPT raporu.**  

![todo:image_alt_text](install-manually_2.png)

Aspose.Slides for Reporting Services'i başarıyla kurdunuz ve raporu bir Microsoft PowerPoint sunumu olarak oluşturduğunuz için tebrikler!