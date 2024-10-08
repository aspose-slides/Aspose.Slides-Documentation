---
title: Почему не автоматизация
type: docs
weight: 50
url: /ru/php-java/why-not-automation/
---

{{% alert color="primary" %}} 

Существует два вопроса, которые мы слышим здесь, в Aspose: 

Первый из них — **Требуется ли установка Microsoft Office для работы ваших продуктов?** 

Краткий и простой ответ — **НЕТ**. Aspose и компоненты Aspose полностью независимы и не связаны с Microsoft Corporation, не являются авторизованными, спонсируемыми или иным образом одобренными этой компанией. 

Второй вопрос, который обычно следует за первым, — **Почему нам следует использовать продукты Aspose, а не Microsoft Office Automation?** 

На этот вопрос нельзя ответить так же легко. Самый короткий ответ, который мы можем дать, это то, что существует множество причин, главная из которых — **сам Microsoft настоятельно не рекомендует использовать автоматизацию Office в программных решениях**. 

{{% /alert %}} 
## **Обзор**
Как уже упоминалось, существует несколько причин, по которым компоненты Aspose являются лучшей альтернативой автоматизации. Некоторые из ключевых причин:

- Безопасность
- Стабильность
- Масштабируемость/Скорость
- Цена
- Функции

Ниже приведены более подробные объяснения каждой из ключевых точек. Также не забудьте посетить раздел **Дополнительная информация**, который содержит ссылки на независимые оценки пользователей. 
## **Безопасность**
Следующее является прямой цитатой из статьи Microsoft: 

*"Программы Office никогда не предназначались для использования на стороне сервера и, следовательно, не учитывают проблемы безопасности, с которыми сталкиваются распределенные компоненты. Office не аутентифицирует входящие запросы и не защищает вас от ненамеренного выполнения макросов или запуска другого сервера, который может запустить макросы, из вашего серверного кода. Не открывайте файлы, загруженные на сервер от анонимного веб-пользователя! В зависимости от настроек безопасности, которые были установлены последними, сервер может выполнять макросы от имени администратора или системного контекста с полными привилегиями и компрометировать вашу сеть! Кроме того, Office использует множество клиентских компонентов (таких как Simple MAPI, WinInet, MSDAIPP), которые могут кешировать информацию об аутентификации клиента для ускорения обработки. Если Office автоматизируется на стороне сервера, один экземпляр может обслуживать более одного клиента, и поскольку информация об аутентификации была кэширована для этой сессии, возможно, что один клиент может использовать кэшированные учетные данные другого клиента и таким образом получить неразрешенные права доступа, выдавая себя за других пользователей."* 

Продукты Aspose очень безопасны. Компоненты Aspose не представляют потенциального риска для жизненно важных системных ресурсов. Кроме того, когда документ открывается компонентом Aspose, макросы не выполняются автоматически. Компоненты Aspose были разработаны с целью позволить разработчикам создавать, изменять и сохранять файлы Office. Ни один из рисков, связанных с пакетом Microsoft Office, не является частью компонентов Aspose. 
## **Стабильность**
Следующее является прямой цитатой из статьи Microsoft:

*"Office 2000, Office XP и Office 2003 используют технологию установки Microsoft Windows Installer (MSI), чтобы упростить установку и самовосстановление для конечного пользователя. MSI вводит концепцию "установки при первом использовании", которая позволяет динамически устанавливать или настраивать функции во время выполнения (для системы или, чаще, для конкретного пользователя). В среде на стороне сервера это как замедляет производительность, так и увеличивает вероятность появления диалогового окна с просьбой пользователя одобрить установку или предоставить соответствующий установочный диск. Хотя это и предназначено для повышения устойчивости Office как продукта для конечных пользователей, реализация возможностей MSI в Office контрпродуктивна в среде на стороне сервера. Более того, стабильность Office в целом не может быть гарантирована при работе на стороне сервера, поскольку она не была разработана или протестирована для такого рода использования. Использование Office как компонента сервиса на сетевом сервере может уменьшить стабильность этого компьютера и, следовательно, вашей сети в целом. Если вы планируете автоматизировать Office на стороне сервера, постарайтесь изолировать программу на выделенном компьютере, который не может повлиять на критические функции и который можно перезапустить по мере необходимости."* 

Компоненты Aspose были тщательно протестированы и крайне стабильны. Компоненты Aspose используются [компаниями](https://about.aspose.com/customers) такими как: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** и многими другими. 
## **Масштабируемость/Скорость**
Следующее является прямой цитатой из статьи Microsoft:

*"Компоненты на стороне сервера должны быть высоко переиспользуемыми, многопоточными компонентами COM с минимальными накладными расходами и высокой пропускной способностью для нескольких клиентов. Программы Office почти во всех аспектах являются точной противоположностью. Они не переиспользуемые, основанные на STA серверы автоматизации, которые предназначены для предоставления разнообразной, но ресурсоемкой функциональности для одного клиента. Они предлагают небольшую масштабируемость как серверное решение и имеют фиксированные пределы для важных элементов, таких как память, которые нельзя изменить через конфигурацию. Более важно то, что они используют глобальные ресурсы (такие как файлы с отображением в памяти, глобальные дополнения или шаблоны и общие серверы автоматизации), которые могут ограничивать количество экземпляров, которые могут выполняться одновременно, и могут привести к состояниям гонки, если они настроены в многоклиентской среде. Разработчики, которые планируют запускать более одного экземпляра любого приложения Office одновременно, должны рассмотреть* ***Пуллинг*** *или* ***Сериализацию доступа*** *к приложению Office, чтобы избежать потенциальных* ***Мониторов блокировки*** *или* ***Порчи данных***.* 

Компоненты Aspose высокомасштабируемы и молниеносно быстры. Программы Office не были предназначены для одновременного использования сотнями и тысячами пользователей. Однако компоненты Aspose разработаны именно для этого. Наши компоненты работают безупречно, как на одном сервере, обеспечивая одно приложение, так и на сбалансированном веб-форме, обеспечивая корпоративное приложение. 
## **Цена**
Когда приложение использует автоматизацию Microsoft Office, нужно приобрести копию Microsoft Office для каждой машины, на которой работает приложение. Часто бывает, что приложение должно создать или изменять офисный файл, но не требует от пользователя наличия Microsoft Office. Aspose предлагает очень [экономическое](https://purchase.aspose.com/) и безвозмездное распространение лицензии, которая позволит развертывание на неограниченном количестве пользователей без проблем с лицензированием. 

При создании веб-приложений важно знать, что компоненты автоматизации Microsoft Office не имеют цен и лицензии для серверных решений; следовательно, нет хорошего решения по лицензированию для развертывания веб-приложений, использующих компоненты Microsoft Office. Aspose также предлагает очень экономичное решение для серверных приложений. 
## **Функции**
Компоненты Aspose предоставляют все необходимое для управления офисными файлами и многое другое. Они разработаны с философией позволить разработчикам достигать наилучших результатов с наименьшими усилиями. В отличие от автоматизации Office, компоненты Aspose предлагают множество мощных функций, которые экономят время. Например, [Aspose.Cells](https://products.aspose.com/cells/php-java/) предлагает разработчикам возможность импортировать данные из **DataTable** или **DataView** непосредственно в файл Excel. [Aspose.Words](https://products.aspose.com/words/php-java/) предлагает аналогичную функцию, позволяющую разработчикам заполнять документ Word (т.е. выполнять слияние почты). [Каждый компонент](https://products.aspose.com/total/php-java/) в семействе Aspose предлагает свой собственный набор уникальных и мощных функций.

Лучшая часть покупки компонента Aspose (или комплектов компонентов, таких как [Aspose.Total](https://products.aspose.com/total/php-java/)) — это доступ к нашим командам разработчиков. Наши команды разработчиков понимают, что если ваша компания нуждается в определенной функции, то, скорее всего, и другим компаниям она также будет нужна. Хотя не каждый запрос на функцию может быть добавлен, наши команды стараются быть открытыми и гибкими, предоставляя помощь. Этот подход помог компонентам Aspose стать столь мощными, какими они являются. Если вам нужны дополнительные функции от объектов автоматизации Office, ваши шансы на их добавление очень низки. 
## **Заключение**
{{% alert color="primary" %}} 

Хотя в этой статье рассмотрены многие ключевые моменты, почему компоненты Aspose являются лучшим выбором, чем автоматизация Office, есть еще много других. Эта статья в основном касается только самых ключевых моментов. Все различные компоненты Aspose предлагают безрисковую, безобязательную [версию для оценки](https://downloads.aspose.com/slides/java). Мы настоятельно рекомендуем воспользоваться этой оценкой, чтобы лучше понять, что Aspose может сделать для ваших приложений.

{{% /alert %}} 