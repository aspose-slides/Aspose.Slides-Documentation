---
title: Настройка демонстрационных проектов
type: docs
weight: 70
url: /ru/jasperreports/demos-setup/
description: "Настройте демонстрационные проекты из загрузки Aspose.Slides for JasperReports, измените используемый ими класс экспортера и собирайте их с помощью Ant."
---
## **Что такое демонстрационные проекты**

Папка *samples* загрузки Aspose.Slides for JasperReports содержит восемь демонстрационных проектов: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* и *xmldatasource*. Это стандартные демо JasperReports, изменённые для добавления цели сборки `ppt`, которая экспортирует заполненный отчёт в PPT. В загрузке нет экспортированных презентаций; вы создаёте их, собирая демо.

## **Измените класс экспортера перед сборкой**

В поставке код демо на Java использует `com.aspose.slides.jasperreports.JRPptExporter`, класс, которого нет в текущих jar‑файлах, поэтому демо не компилируются. В классе приложения демо (например, *ShapesApp.java* в демо *shapes*) замените `JRPptExporter` на `ASPptExporter` — PPT‑экспортер из того же пакета. Демо *fonts* импортирует весь пакет, поэтому меняется только имя класса в его коде.

Демо также используют классы JasperReports, которые были удалены в более поздних версиях JasperReports, такие как `JExcelApiExporter` и `JRExporterParameter.FONT_MAP`. После вышеуказанных изменений демо компилируются следующим образом:

| Версия JasperReports | Демо, которые компилируются |
| :- | :- |
| 5.5.1 | все восемь |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* and *xmldatasource* |
| 6.16.0 | *charts* |

## **Сборка демо**

Каждый *build.xml* демо ожидает структуру каталогов проекта JasperReports: он компилируется против *../../../build/classes* и jar‑файлов в *../../../lib*, относительно папки демо.

1. Скопируйте папку демо в *demo/samples* в папке вашего проекта JasperReports.  
2. Скопируйте *aspose.slides.jasperreports.library-xx.x.jar* из подпапки *lib* загрузки, соответствующей вашей версии JasperReports, в папку *lib* проекта JasperReports. Смотрите [Installing Aspose.Slides for JasperReports](/slides/ru/jasperreports/installing-aspose-slides-for-jasperreports/).  
3. Поместите jar‑файл вашей версии JasperReports и его зависимости в ту же папку *lib*. Помимо файлов демо, *build.xml* добавляет в classpath только *build/classes* и jar‑файлы из *lib*, а *build/classes* содержит классы JasperReports только после сборки JasperReports из исходников.  
4. Демо *charts*, *subreport* и *text* читают образец базы данных HSQLDB JasperReports (`jdbc:hsqldb:hsql://localhost`), поэтому запустите её сервер сначала, как описано в *samples/Readme.txt* загрузки. Остальные демо не требуют базы данных.  
5. В папке демо скомпилируйте приложение, скомпилируйте дизайн отчёта, заполните его и экспортируйте в PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

Цель `ppt` записывает презентацию рядом с заполненным отчётом, используя имя отчёта (например, *LandscapeReport.ppt*).

Два демо требуют дополнительных действий помимо перечисленных выше:

- Демо *images* загружает одну картинку из `http://jasperreports.sourceforge.net/jasperreports.png` при экспорте. Сейчас этот адрес перенаправляет на HTTPS, поэтому шаг `ppt` не создаёт презентацию, пока вы не измените адрес на `https://` в *ImagesReport.jrxml*. При JasperReports 6.4.0 экспорт этой картинки не удаётся даже по HTTPS.  
- Отчёт *xmldatasource* использует шрифт Arial. На системе без Arial команда `ant fill` выводит, что шрифт «не доступен JVM», и не создаёт заполненный отчёт, поэтому `ant ppt` нечему экспортировать. Сборка всё равно считается успешной, поэтому проверяйте вывод каждого шага.