---
title: Часто задаваемые вопросы
type: docs
weight: 110
url: /ru/reportingservices/chasto-zadavaemye-voprosy/
---

{{% alert color="primary" %}} 

Эта страница собирает ряд часто задаваемых вопросов о:

- [Поддерживаемых форматах файлов](#Поддерживаемые-форматы-файлов).
- [Поддержке Power BI и сервисов отчетности](#Поддержка-Power-BI-и-сервисов-отчетности).
- [Установке](#Установка).
- [Конфигурации экспорта](#Конфигурация-экспорта).

{{% /alert %}} 
### **Поддерживаемые форматы файлов**
#### **Q: В какие форматы можно экспортировать отчеты с помощью Aspose.Slides для Reporting Services?**
**A**: Aspose.Slides для Reporting Services позволяет экспортировать любой отчет в формате PPT, PPS, PPTX, PPSX, XPS или RPL.
### **Поддержка Power BI и сервисов отчетности**
#### **Q: Поддерживает ли Aspose.Slides для Reporting Services Power BI?**
**A**: Да. Aspose.Slides для Reporting Services поддерживает экспорт страничных отчетов (RDL) в Power BI.
### **Установка**
#### **Q: Установочная программа не запускается. Ручная установка не приводит к желаемому результату.**
**A**: Убедитесь, что на вашей системе установлен .NET Framework 3.5.
#### **Q: Опции экспорта отсутствуют после установки Aspose.Slides для Reporting Services.**
**A**: Если какая-либо ГруппаКода в rssrvpolicy.config работает некорректно, парсер конфигурационного файла может пропустить последние разделы группы. Поэтому переместите все ГруппыКода, связанные с Aspose.Slides для Reporting Services, в верхнюю часть блока, содержащего ГруппыКода Aspose.Slides для Reporting Services.
#### **Q: Не удалось загрузить файл или сборку Aspose.Slides.ReportingServices (Невозможно получить разрешение на выполнение \ Исключение из HRESULT: 0x80131418).**
**A**: Код ошибки (0x80131418) указывает на то, что модуль dll не имеет достаточных прав. Это может быть связано с функцией безопасности, которая заблокировала полный доступ к файлу .dll, если он был получен с другого компьютера. Это можно исправить, открыв окно свойств файла dll и нажав кнопку "Разблокировать" на панели "Безопасность".
#### **Q: Не удается найти лицензию 'Aspose.Slides.Reporting.Services.lic'.**
**A**: Файл лицензии должен находиться рядом с файлом dll или в директории Program Files(x86)\Aspose\Slides\.
### **Конфигурация экспорта**
#### **Q: Как я могу изменить цвет гиперссылок в экспортированном отчете?**
**A**: У каждого расширения рендеринга Aspose.Slides для Reporting Services в rsreportserver.config есть своя конфигурация. Чтобы изменить цвет гиперссылки, установите требуемое значение в разделе <HyperlinkColor>.
#### **Q: В экспортированных представлениях текст в таблицах растянут по вертикали.**
**A**: Это сделано для того, чтобы документ было легче читать. Чтобы отобразить текст в таблице так, как он появляется в отчете, установите нужное расширение Aspose.Slides для Reporting Services на "Обычный" в конфигурационном файле rsreportserver.config.
