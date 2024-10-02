---  
title: Легкое и легковесное развертывание  
type: docs  
weight: 50  
url: /ru/reportingservices/easy-and-lightweight-deployment/  
---  

{{% alert color="primary" %}}  

Aspose.Slides для Reporting Services — это [расширение рендеринга](http://msdn2.microsoft.com/en-us/library/ms154606.aspx) для Microsoft SQL Server Reporting Services.  
Aspose.Slides для Reporting Services предоставляется в виде одного MSI-установщика, который может быть установлен на компьютерах с одной из следующих версий:  

- Microsoft SQL Server 2005 Reporting Services (32-разрядная и 64-разрядная)  
- Microsoft SQL Server 2008 Reporting Services (32-разрядная и 64-разрядная)  

Также легко развернуть и управлять Aspose.Slides для Reporting Services вручную, так как это всего лишь одна сборка .NET *Aspose.Slides* *.ReportingServices.dll*, написанная полностью на C#, совместимая с CLS и содержащая только безопасный управляемый код.  

{{% /alert %}}  

MSI-установщик и ZIP-загрузка включают Aspose.Slides для Reporting Services:  

- Bin\SSRS2005\Aspose.Slides.ReportingServices.dll — создан для Microsoft SQL Server 2005 и .NET Framework 2.0 (использовать для x86 и x64)  
- Bin\SSRS2008\Aspose.Slides.ReportingServices.dll — создан для Microsoft SQL Server 2008 и .NET Framework 2.0 (использовать для x86 и x64)  

При установке Aspose.Slides.ReportingServices.dll копируется в директорию ReportServer\bin, и файл конфигурации обновляется, чтобы Reporting Services знало о новом расширении рендеринга. Эти шаги выполняются установщиком Aspose.Slides для Reporting Services, но вы также можете выполнить их вручную, как описано далее в этой документации.  

![todo:image_alt_text](easy-and-lightweight-deployment_1.png)  

**Рисунок**: Aspose.Slides.ReportingServices.dll скопирован в директорию **ReportServer\bin**.  