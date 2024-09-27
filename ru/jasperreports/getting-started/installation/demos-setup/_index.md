---
title: Настройка демонстраций
type: docs
weight: 70
url: /ru/jasperreports/demos-setup/
---


Все демонстрации, предоставленные с Aspose.Slides для JasperReports, являются измененными стандартными демонстрациями. Лучше всего скопировать все демонстрации в папку демонстраций JasperReports:
...\jasperreports-x.x.x\demo\samples\

Используйте стандартную последовательность команд для сборки и экспорта отчетов:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 

Пожалуйста, не забудьте запустить HSQLDB с тестовой базой данных, чтобы заполнить отчеты данными и скопировать aspose.slides.jasperreports.library-xx.x.jar из папки \lib\JasperReports X.X.X - X.X.X файла aspose-slides-xx.x-jasperreports.zip в каталог &#60;InstallDir&#62;\lib.

{{% /alert %}} 

Большинство демонстраций (за исключением графиков) уже имеют сгенерированные презентации, поэтому вы можете пропустить все этапы "ant" и сразу проверить результаты.