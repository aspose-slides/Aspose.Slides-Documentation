---
title: Безопасность
type: docs
weight: 160
url: /ru/net/security/
keywords:
- безопасность
- зависимости
- сторонние компоненты
- NuGet
- сканирование уязвимостей
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Обзор того, как Aspose.Slides for .NET обрабатывает презентации, какие пакеты NuGet требуются для каждой целевой платформы и какие сторонние компоненты включены."
---
## **Безопасность в Aspose.Slides**

Aspose применяет лучшие практики при разработке своих продуктов.

* Aspose.Slides for .NET используется для работы с презентациями и их преобразования в другие форматы. Он не исполняет сценарии в презентациях. Aspose.Slides разбирает структуру презентации и позволяет коду конечного пользователя удобно манипулировать объектной моделью.
* Aspose.Slides функционирует как библиотека, которая разбирает и интерпретирует документы без выполнения удалённого кода. Все продукты Aspose работают на ваших машинах. Они не передают никаких данных в Aspose. Единственное исключение — [metered license](https://purchase.aspose.com/faqs/licensing/metered): если вы используете её, обрабатывается только информация об использовании API.
* Компоненты Aspose работают в том же пользовательском контексте, что и обычные приложения. Поэтому компоненты Aspose не представляют угрозу для критически важных системных ресурсов. Более того, при открытии документа компонентом Aspose макросы не запускаются автоматически.
* Риски, присущие или связанные с пакетом Microsoft Office, не применимы к компонентам Aspose, поэтому продукты Aspose очень безопасны.

## **Зависимости NuGet**

Aspose.Slides for .NET зависит от пакетов, которые Microsoft публикует в NuGet. Зависимости различаются в зависимости от пакета и целевой платформы:

| Пакет | Целевая платформа | Зависимости |
|---|---|---|
| Aspose.Slides.NET | `net462` | System.Text.Json |
| Aspose.Slides.NET | `net6.0` | System.Drawing.Common, System.Security.Cryptography.Xml |
| Aspose.Slides.NET | `netstandard2.0` | System.Drawing.Common, System.Security.Cryptography.Xml, System.Text.Encoding.CodePages, System.Text.Json |
| Aspose.Slides.NET6.CrossPlatform | `net6.0` | System.Security.Cryptography.Xml |

Раздел **Dependencies** страниц [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) и [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) в NuGet перечисляет минимальную версию каждой зависимости для каждого выпуска.

При добавлении Aspose.Slides в проект NuGet также восстанавливает зависимости этих пакетов. Чтобы вывести список всех пакетов, которые восстанавливает ваш проект, включая транзитивные зависимости, выполните эту команду в папке проекта:

```bash
dotnet list package --include-transitive
```

Чтобы проверить тот же набор пакетов на наличие известных уязвимостей, выполните:

```bash
dotnet list package --vulnerable --include-transitive
```

Для других способов аудита пакетов NuGet см. [Auditing package dependencies for security vulnerabilities](https://learn.microsoft.com/en-us/nuget/concepts/auditing-packages).

## **Сторонние компоненты**

Aspose.Slides включает код из сторонних открытых компонентов. Они являются частью продукта, а не отдельными пакетами NuGet, поэтому инструменты, которые читают только зависимости NuGet, их не показывают. Оба пакета содержат файл *thirdpartylicenses.Aspose.Slides.for.NET.pdf*, в котором перечислены компоненты и их лицензии:

| Компонент | Лицензия, указанная в уведомлении |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |
| Skia | BSD-style license |
| HarfBuzz | "Old MIT" license |
| Boost | Boost Software License 1.0 |
| Double Conversion | BSD-style license |
| ICU (International Components for Unicode) | Unicode copyright and terms of use |

## **Вопросы и ответы**

**Какие системы используются для мониторинга уязвимостей в коде Aspose?**

Мы проводим статический анализ кода для каждого выпуска Aspose.Slides. Мы можем предоставить отчёты о безопасности, подтверждающие, что код Aspose.Slides соответствует OWASP Top 10.

**Использует ли Aspose.Slides внешние пакеты?**

Да. Он зависит от перечисленных в разделе [Зависимости NuGet](#nuget-dependencies) пакетов Microsoft и включает сторонние компоненты, перечисленные в разделе [Сторонние компоненты](#third-party-components). Учтите оба аспекта в вашем обзоре безопасности и используйте `dotnet list package --vulnerable --include-transitive`, чтобы проверить уязвимости пакетов NuGet, восстанавливаемых вашим проектом.