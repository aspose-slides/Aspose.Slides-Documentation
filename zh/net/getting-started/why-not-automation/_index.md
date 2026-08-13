---
title: "为什么不使用自动化"
type: docs
weight: 40
url: /zh/net/why-not-automation/
keywords:
- 自动化
- 微软 Office
- 比较
- 安全
- 稳定性
- 可扩展性
- 功能
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解为何 Office 自动化对服务器和服务风险较大，并了解 Aspose.Slides 如何为 PowerPoint 和 OpenDocument 提供更安全、更快速的演示处理。"
---
## **介绍**

Aspose 组件在许多方面是比自动化更好的替代方案。主要原因包括：

- 安全性
- 稳定性
- 可扩展性/速度
- 价格
- 功能

以下是对每个关键点的更详细解释。

## **重要问题**

我们在 Aspose 经常听到两个问题：

- 您的产品是否需要安装 Microsoft Office 才能运行？

简短而明确的答案是 **否**。

Aspose 组件是完全独立的，未与 Microsoft 公司关联、授权、赞助或以任何方式获得认可。

- 为什么我们应该使用 Aspose 产品而非 Microsoft Office 自动化？

首先，使用 Aspose.Slides 时您可以享受许多[使用 Aspose.Slides 时的好处](/slides/zh/net/product-overview/)。

其次，Microsoft 本身强烈**建议不要**在软件解决方案中使用 Office 自动化。

## **安全性**
以下摘自 Microsoft 文章的原文：

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Aspose 产品非常**安全**。Aspose 组件在与所有 ASP.NET 应用程序相同的用户上下文中运行（在 ASPNET 用户下）。因此，Aspose 组件**不会**构成安全风险。它们也不会消耗关键系统资源。此外，当 Aspose 组件打开文档时，宏不会自动运行。Aspose 组件旨在帮助开发者创建、操作和保存 Office 文件。

{{% alert color="info" %}} 
Microsoft Office 包相关的风险均不适用于 Aspose 组件。
{{% /alert %}} 

## **稳定性**
以下文本摘自前面引用的 Microsoft 文章：

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

由于 Aspose 组件打包为单个 DLL，用户无需为其功能再安装任何额外部件。Aspose 组件仅供 .NET 应用程序使用，且组件代码中没有任何需要人工响应的部分。

{{% alert color="info" %}} 
Aspose 组件已经过彻底测试并确认非常稳定。Aspose 组件被[公司](http://www.aspose.com/Corporate/Aspose/Customerlist.html)如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America**等多家行业领先组织使用。
{{% /alert %}} 

## **可扩展性/速度**
以下摘自 Microsoft 文章的原文：

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Aspose 组件具有极高的可扩展性和闪电般的速度。Office 应用程序并未设计用于数百或数千用户同时使用，而 Aspose 组件正是为此而生。我们的组件是真正的 .NET 解决方案。

{{% alert color="info" %}} 
Aspose 组件在单台服务器（支撑单个应用）或负载均衡的 Web 环境（支撑企业级应用）中性能均无可挑剔。
{{% /alert %}} 

## **价格**
当应用程序使用 Microsoft Office 自动化时，需要为每台运行该应用的机器购买 Microsoft Office 许可证。尽管应用可能需要创建或操作 Office 文件，但该过程并不需要 Microsoft Office。

{{% alert color="info" %}} 
Aspose 提供极具[性价比](https://purchase.aspose.com/)且免版税的再分发许可证，允许无限用户部署，无需担心授权问题。
{{% /alert %}} 

在创建基于 Web 的应用时，需要牢记 Microsoft Office 自动化组件既没有针对服务器端的定价，也没有相应的授权。因此，使用 Microsoft Office 组件的 Web 应用部署缺乏合适的许可方案。而 Aspose 则同样提供极具[性价比](https://purchase.aspose.com/)的服务器端应用解决方案。

## **功能**
Aspose 组件提供管理 Office 文件所需的一切，甚至更多。我们基于帮助开发者以最少的工作量实现最大成果的理念来设计它们。

{{% alert color="info" %}} 
与 Office 自动化不同，Aspose 组件提供众多强大且省时的功能。
{{% /alert %}} 

例如，[Aspose.Cells](https://products.aspose.com/cells/net/) 让开发者能够直接将 **DataTable** 或 **DataView** 数据导入到 Excel 文件中。[Aspose.Words](https://products.aspose.com/words/net/) 提供类似功能，允许开发者直接从任何 .NET 数据对象填充 Word（即邮件合并）文档。Aspose 系列中的[每个组件](https://products.aspose.com/total/net/)都拥有各自独特且强大的功能。

购买 Aspose 组件的最大好处是可以获得我们开发团队的支持。例如，如果您使用 Office 自动化对象并需要特定功能，添加这些功能的可能性极低。而 Aspose 组件则截然不同。

{{% alert color="info" %}} 
我们的开发团队明白，如果贵公司需要某项功能，很可能其他公司也有相同需求。虽然我们无法实现所有请求的功能，但会根据客户反馈尽可能添加更多功能。
{{% /alert %}} 

我们的团队在提供帮助时始终保持开放和灵活，这也是 Aspose 组件日益强大的原因。

## **结论**
{{% alert color="info" %}} 
虽然本文已覆盖 Aspose 组件相较于 Office 自动化更佳的部分关键点，但您应了解还有许多更多的优势。我们仅列举了部分主要优点。

此外，所有 Aspose 产品和组件均提供免费、无义务的[评估版](https://downloads.aspose.com/slides/zh/net)。我们鼓励您利用评估版，了解 Aspose 能为您的应用或业务带来什么。
{{% /alert %}}