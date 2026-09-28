---
title: Почему не использовать автоматизацию
type: docs
weight: 170
url: /ru/net/why-not-automation/
keywords:
- автоматизация
- Microsoft Office
- сравнение
- безопасность
- стабильность
- масштабируемость
- функциональность
- PowerPoint
- OpenDocument
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, почему автоматизация Office опасна для серверов и сервисов, и как Aspose.Slides обеспечивает более безопасную и быструю обработку презентаций для PowerPoint и OpenDocument."
---
## **Введение**

Существует несколько причин, почему компоненты Aspose являются лучшей альтернативой автоматизации. Некоторые из ключевых причин:

- Безопасность
- Стабильность
- Масштабируемость/Скорость
- Цена
- Функциональность

Ниже более подробное объяснение каждого ключевого пункта.

## **Важные вопросы**

Есть два вопроса, которые мы часто слышим в Aspose:

- Требуется ли для работы ваших продуктов установка Microsoft Office?

Краткий, простой ответ — **NO**.

Компоненты Aspose полностью независимы и не являются аффилированными, уполномоченными, спонсируемыми или иным образом одобренными корпорацией Microsoft.

- Почему нам следует использовать продукты Aspose вместо автоматизации Microsoft Office?

First, there are many [много преимуществ, которые вы получаете, используя Aspose.Slides](/slides/ru/net/product-overview/).

Second, Microsoft itself strongly **не рекомендует** using Office Automation from software solutions.

## **Безопасность**
Ниже приведена прямая цитата из статьи Microsoft:

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Продукты Aspose очень **безопасны**. Компоненты Aspose работают в том же пользовательском контексте, что и все приложения ASP.NET (под пользователем ASPNET). Поэтому компоненты Aspose **не** представляют угрозу безопасности. Они также не потребляют критические системные ресурсы. Более того, когда компонент Aspose открывает документ, макросы не запускаются автоматически. Компоненты Aspose созданы для того, чтобы разработчики могли создавать, изменять и сохранять файлы Office.

{{% alert color="info" title="Note" %}}
Ни один из рисков, связанных с пакетом Microsoft Office, не применяется к компонентам Aspose.
{{% /alert %}}

## **Стабильность**
Это текст прямой цитаты из ранее упомянутой статьи Microsoft:

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of \"install on first use\", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Поскольку компоненты Aspose упакованы в один DLL, их пользователям никогда не требуется устанавливать дополнительные части или модули для их работы. Компоненты Aspose используются только .NET‑приложениями и в их коде нет части, ожидающей человеческого ответа.

{{% alert color="info" title="Note" %}}
Компоненты Aspose прошли тщательное тестирование и подтверждены как очень стабильные. Компоненты Aspose используют [компаниями](https://about.aspose.com/customers/) such as **Bank of America** и многие другие ведущие организации в различных отраслях.
{{% /alert %}}

## **Масштабируемость/Скорость**
Ниже приведена прямая цитата из статьи Microsoft:

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Компоненты Aspose невероятно масштабируемы и молниеносно быстры. Приложения Office не были разработаны для одновременного использования сотнями или тысячами пользователей, тогда как компоненты Aspose созданы именно для этого. Наши компоненты – истинное .NET‑решение.

{{% alert color="info" title="Note" %}}
Производительность компонентов Aspose безупречна как на отдельном сервере (обслуживающем одно приложение), так и в балансируемой веб‑форме (обслуживающей корпоративное приложение).
{{% /alert %}}

## **Цена**
Когда приложение использует автоматизацию Microsoft Office, копию Microsoft Office необходимо приобрести для каждой машины, на которой запускается приложение. Есть множество сценариев, когда приложение может создавать или изменять офисный файл, но процесс не требует Microsoft Office.

{{% alert color="info" title="Note" %}}
Aspose предоставляет очень [экономичную](https://purchase.aspose.com/) и royalty‑free лицензию на распространение, позволяющую развертывать решение для неограниченного количества пользователей без лицензирующих проблем.
{{% /alert %}}

При создании веб‑приложений важно помнить, что компоненты автоматизации Microsoft Office не имеют цены и лицензии для серверных решений. Поэтому нет надёжного лицензирования для развертывания веб‑приложений, использующих компоненты Microsoft Office. Aspose, с другой стороны, предлагает очень [экономичное](https://purchase.aspose.com/) решение для серверных приложений.

## **Функциональность**
Компоненты Aspose предоставляют всё необходимое для работы с офисными файлами и многое больше. Мы разработали их, руководствуясь философией помощи разработчикам в достижении максимальных результатов с минимальными затратами усилий.

{{% alert color="info" title="Note" %}}
В отличие от автоматизации Office, компоненты Aspose предоставляют множество мощных и экономящих время функций.
{{% /alert %}}

Например, [Aspose.Cells](https://products.aspose.com/cells/net/) дает разработчикам возможность импортировать данные из **DataTable** или **DataView** напрямую в файл Excel. [Aspose.Words](https://products.aspose.com/words/net/) предоставляет аналогичную возможность заполнения Word‑документа (Mail Merge) напрямую из любого .NET‑объекта данных. [Every component](https://products.aspose.com/total/net/) семейства Aspose предлагает свой уникальный набор мощных функций.

Самая лучшая часть покупки компонента Aspose — доступ к нашим командам разработки. Например, если вы используете объекты автоматизации Office и вам нужны определённые функции, вероятность того, что эти функции будут добавлены, крайне низка. С компонентами Aspose всё иначе.

{{% alert color="info" title="Note" %}}
Наши команды разработки понимают, что если ваша компания нуждается в функции, то, скорее всего, её нуждаются и другие фирмы. Хотя мы знаем, что не можем реализовать каждую запрошенную функцию, мы стремимся добавить как можно больше функций на основе обратной связи от наших клиентов.
{{% /alert %}}

Наши команды всегда открыты и гибки при предоставлении помощи — и именно поэтому компоненты Aspose стали такими мощными, как они есть сейчас.

## **Заключение**
{{% alert color="info" title="Note" %}}
Хотя в этой статье рассмотрены некоторые ключевые причины, почему компоненты Aspose лучше, чем автоматизация Office, следует понимать, что преимуществ гораздо больше. Мы перечислили лишь часть основных преимуществ.

Кроме того, все продукты и компоненты Aspose предлагают бесплатную, безобязательную [Evaluation Version](https://releases.aspose.com/slides/net/). Мы настоятельно рекомендуем воспользоваться оценкой, чтобы увидеть, что Aspose может сделать для ваших приложений или бизнеса.
{{% /alert %}}