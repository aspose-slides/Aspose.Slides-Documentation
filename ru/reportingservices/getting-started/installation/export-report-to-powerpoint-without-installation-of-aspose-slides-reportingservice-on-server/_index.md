---
title: Экспорт отчета в Powerpoint без установки Aspose.Slides.ReportingService на сервере
type: docs
weight: 120
url: /ru/reportingservices/export-report-to-powerpoint-without-installation-of-aspose-slides-reportingservice-on-server/
---

{{% alert color="primary" %}} 

Aspose.Slides для Reporting Service можно использовать без установки на сервере. Этот подход подходит, когда необходимо интегрировать экспорт в Powerpoint в ваше приложение, но доступ к сервису ограничен.

{{% /alert %}} {{% alert color="primary" %}} 

Решение для Visual Studio, иллюстрирующее подход, можно найти [здесь](attachments/10289165/10453062.zip).

{{% /alert %}} 

Процесс рендеринга состоит из двух частей: 

1. Рендеринг отчета в RPL с использованием веб-сервиса Reporting Service. Дополнительную информацию о веб-сервисе Reporting Service см. [здесь](http://technet.microsoft.com/en-us/library/ms152787.aspx).
1. Рендеринг RPL в Powerpoint с использованием Aspose.Slides для Reporting Service для ReportViewer. Сборка расположена в ﻿﻿﻿﻿﻿{Aspose.Slides для Reporting Services домашний каталог}\bin\RV2010  
## **Как реализовать экспорт в PowerPoint:**
 1) Создайте прокси веб-сервиса (см. детали [здесь](http://technet.microsoft.com/en-us/library/ms155134.aspx)) и добавьте его в ваше решение.

 2) Добавьте ссылку на Aspose.Slides.ReportingServices.dll для ReportViewer 2010.

 3) Используйте этот класс для интеграции прокси веб-сервиса и Aspose.Slides для Reporting Service

``` xml

 class PowerpointRenderer

{

/// <summary>

/// Получает или задает базовый URL XML веб-сервиса, запрашиваемого клиентом.

/// </summary>

/// <value>

/// Базовый URL XML веб-сервиса, запрашиваемого клиентом. Значение по умолчанию — System.String.Empty.

/// </value>

public string ReportingServiceUrl { get; set; }


/// <summary>

/// Получает или задает имя пользователя для Reporting Service.

/// </summary>

/// <value>

/// Имя пользователя.

/// </value>

public string Username { get; set; }

/// <summary>

/// Получает или задает пароль для Reporting Service.

/// </summary>

/// <value>

/// Пароль.

/// </value>

public string Password { get; set; }

/// <summary>

/// Рендерит указанный отчет в файл.

/// </summary>

/// <param name="outputFileName">Имя выходного файла.</param>

/// <param name="reportPath">Путь к отчету.</param>

/// <param name="format">Формат выходной презентации.</param>

public void Render(string outputFileName, string reportPath, Aspose.Slides.ReportingServices.OutputPresentationFormat format)

{

using (FileStream pptSteam = new FileStream(outputFileName, FileMode.Create))

{

Aspose.Slides.ReportingServices.RplRenderer renderer = new Aspose.Slides.ReportingServices.RplRenderer();

//начало процесса рендеринга

//здесь мы выбираем экспорт в формат PPT и предоставляем выходной поток

renderer.StartRendering(format, false);

int page = 1;

//этот цикл выполняется для всех страниц отчета

while (true)

{

using (MemoryStream rplStream = CreateRplStream(page, reportPath))

{

//если rplStream пустой, значит, мы достигли конца отчета

if (rplStream.Length == 0)

break;

//добавление страницы отчета как слайда в документ

renderer.RenderPage(rplStream);

}

page++;

}

//вызов метода завершения для очистки нашей новосозданной презентации в выходной поток

renderer.FinishRendering(pptSteam);

}

}

private MemoryStream CreateRplStream(int page, string reportPath)

{

ReportExecutionService _executionService = new ReportExecutionService();

_executionService.Url = ReportingServiceUrl + "/ReportExecution2005.asmx";

_executionService.Credentials = new System.Net.NetworkCredential(Username, Password, string.Empty);

string extension;

Warning[] warnings;

string[] streamIds;

string mimeType;

string encoding;

var executionInfo = _executionService.LoadReport(reportPath, null);

string deviceInfo = String.Format(

@"<DeviceInfo>

<StartPage>{0}</StartPage>

<EndPage>{0}</EndPage>

<SecondaryStreams>Embedded</SecondaryStreams>

</DeviceInfo>", page);

byte[] result = _executionService.Render("RPL", deviceInfo, out extension, out mimeType, out encoding, out warnings, out streamIds);

return new MemoryStream(result);

}

```

 4) Теперь вы можете экспортировать отчет через этот код:

``` xml

 PowerpointRenderer powerpointRenderer = new PowerpointRenderer();

powerpointRenderer.ReportingServiceUrl = "http://<Имя сервера>/Reportserver";

powerpointRenderer.Username = "Имя пользователя";

powerpointRenderer.Password = "пароль";

powerpointRenderer.Render("test.ppt", "/AdventureWorks Sample Reports/Sales Order Detail SQL2008R2", Aspose.Slides.ReportingServices.OutputPresentationFormat.Ppt);

```

{{% alert color="primary" %}} 

Процесс экспорта здесь использует мягкие разрывы страниц, аналогичные Word или Excel, поэтому его результат может отличаться от Презентации, экспортированной с использованием стандартного подхода.

{{% /alert %}}