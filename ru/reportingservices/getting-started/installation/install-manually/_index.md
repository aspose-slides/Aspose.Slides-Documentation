---
title: Установка вручную
type: docs
weight: 30
url: /ru/reportingservices/install-manually/
---

{{% alert color="primary" %}} 

Следуйте этим шагам только в том случае, если планируете установить Aspose.Slides для Reporting Services вручную. В этом случае вы загрузили ZIP-архив, содержащий файлы сборки.

{{% /alert %}} 

{{% alert title="Примечание" color="warning" %}} 

**Aspose.Slides для Reporting Services** требует установки **.NET Framework 3.5** на хост-машине.

{{% /alert %}}

### **Ручная установка**
Эти инструкции показывают, как скопировать и изменить файлы в директории, где установлены службы отчетности Microsoft SQL Server:

1. Найдите директорию установки сервера отчетов.
   Корневая директория для Microsoft SQL Server обычно находится здесь: ***C:\Program Files\Microsoft SQL Server***
   
   {{% alert color="primary" %}} 
   
   **Microsoft SQL Server 2005 и 2008**: На машине может быть настроено несколько экземпляров Microsoft SQL Server, которые могут занимать разные подкаталоги MSSQL.x, такие как MSSQL.1, MSSQL.2 и так далее. Вы должны найти правильную директорию ***C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer***, прежде чем продолжить к следующему шагу.
   
   {{% /alert %}} Все пути, использованные ниже, будут ссылаться на эту директорию как <Instance>. 

2. Скопируйте Aspose.Slides.ReportingServices.dll в папку **C:\Program Files\Microsoft SQL Server\xxx\Reporting Services\ReportServer\bin**.
   Загрузки **Aspose.Slides.ReportingServices.zip** содержат **Aspose.Slides.ReportingServices.dll**. {{% alert color="primary" %}} 

В некоторых случаях, когда вы копируете DLL в директорию **ReportServer\bin**, она может быть скопирована вместе с явными разрешениями NTFS, назначенными ей. Разрешения NTFS могут привести к тому, что Microsoft SQL Server Reporting Services откажет в доступе при загрузке **Aspose.Slides.ReportingServices.dll**. Если это произойдет, новые форматы экспорта не станут доступными. Проверьте и подтвердите, что правильные разрешения NTFS настроены:

   1. Щелкните правой кнопкой мыши на **Aspose.Slides.ReportingServices.dll**.
   1. Выберите **Свойства** и перейдите на вкладку **Безопасность**.
   1. Удалите любые явно назначенные разрешения NTFS и оставьте только унаследованные разрешения.

{{% /alert %}}

3. Зарегистрируйте Aspose.Slides для Reporting Services как расширение рендеринга: 
   1. Откройте *C:\Program
      Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config*.
   1. Добавьте эти строки в элемент <Render>: 

**<Render>**

``` xml

   ...

  <!--Начните здесь.-->

  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

  <!--Закончите здесь.-->

</Render>

```

4. Дайте Aspose.Slides для Reporting Services разрешение на выполнение: 
   1. Откройте **C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config**.
   1. Добавьте следующее в качестве последнего элемента в самом внешнем элементе <CodeGroup> (который должен быть <CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="Эта группа кода предоставляет разрешение на выполнение кода MyComputer. ">). 

**<CodeGroup>**

``` xml

...

  <CodeGroup>

    ...

    <!--Начните здесь.-->

    <CodeGroup

        class="UnionCodeGroup"

        version="1"

        PermissionSetName="FullTrust"

        Name="Aspose.Slides_for_Reporting_Services"

        Description="Эта группа кода предоставляет полное доверие к сборке AS4SSRS.">

        <IMembershipCondition

            class="StrongNameMembershipCondition"

            version="1"

            PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001005542e

            99cecd28842dad186257b2c7b6ae9b5947e51e0b17b4ac6d8cecd3e01c4d20658c5e4ea1b9a6c8f854b2

            d796c4fde740dac65e834167758cff283eed1be5c9a812022b015a902e0b97d4e95569eb8c0971834744

            e633d9cb4c4a6d8eda03c12f486e13a1a0cb1aa101ad94943236384cbbf5c679944b994de9546e493bf" />

    </CodeGroup>

    <!--Закончите здесь.-->

  </CodeGroup>

</CodeGroup>

```

5. Проверьте, что Aspose.Slides для Reporting Services была успешно установлена: 
   1. Откройте Менеджер отчетов и проверьте список доступных типов экспорта для отчета. 
   
      {{% alert color="primary" %}} Вы можете запустить Менеджер отчетов, открыв браузер (Microsoft Internet Explorer 6.0 или новее) и введя URL-адрес Менеджера отчетов в адресной строке (по умолчанию это http://< ComputerName >/Reports ). 
   
      {{% /alert %}}

1. Выберите отчет на сервере.
1. Откройте список **Выбрать формат**.
   Вы должны увидеть список форматов экспорта, предоставленных Aspose.Slides для Reporting Services. 
1. Выберите **PPT – Презентация PowerPoint через Aspose.Slides**. 

   **Aspose.Slides для Reporting Services успешно установлена, и новые форматы экспорта доступны.** 

![todo:image_alt_text](install-manually_1.png)



6. Нажмите на ссылку **Экспорт**.
   Отчет генерируется в выбранном формате, отправляется клиенту, а затем открывается в соответствующем приложении. В нашем случае отчет был открыт в Microsoft PowerPoint. 

   **Отчет PPT, сгенерированный Aspose.Slides для Reporting Services.** 

![todo:image_alt_text](install-manually_2.png)

Вы успешно установили Aspose.Slides для Reporting Services и сгенерировали отчет в виде презентации Microsoft PowerPoint! 
