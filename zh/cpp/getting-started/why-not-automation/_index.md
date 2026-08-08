---
title: 为什么不使用自动化
type: docs
weight: 50
url: /zh/cpp/why-not-automation/
keywords:
- 自动化
- Microsoft Office
- 比较
- 安全性
- 稳定性
- 可伸缩性
- 功能
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解为何在服务器和服务中使用 Office 自动化存在风险，以及 Aspose.Slides 如何为 PowerPoint 和 OpenDocument 提供更安全、更快速的演示处理。"
---
## **简介**

Aspose 组件成为自动化更好替代方案的原因有多个。主要原因包括：

- 安全性
- 稳定性
- 可伸缩性/速度
- 价格
- 功能

以下是对每个关键点的更详细说明。

## **重要问题**
- 为什么 Aspose 组件远比 Microsoft Office 自动化更好的选择？

在 Aspose，我们最常听到的两个问题是：

- 您的产品是否需要安装 Microsoft Office 才能运行？

简短明确的答案是 **NO**。Aspose 及 Aspose 组件完全独立，且不隶属、未得到授权、赞助或以其他方式获得 Microsoft Corporation 的批准。

- 我们为什么要使用 Aspose 产品而不是使用 Microsoft Office 自动化？

我们能给出的最简短答案是，有许多原因，其中最重要的是 Microsoft 本身强烈建议不要在软件解决方案中使用 Office 自动化：[Microsoft Article

## **安全性**
以下内容直接摘自上述引用的 Microsoft Article：

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Aspose 产品非常安全。因此，Aspose 组件不会对关键系统资源构成潜在风险。此外，当文档被 Aspose 组件打开时，宏不会自动运行。Aspose 组件的构建目标是让开发者能够创建、操作并保存 Office 文件。与 Microsoft Office 包相关的风险并不固有于 Aspose 组件。

## **稳定性**
以下内容直接摘自上述引用的 Microsoft Article：

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

由于 Aspose 组件被打包成单个 DLL，永远不需要安装任何额外的部件来运行。Aspose 组件仅由 C++ 应用程序使用，且没有任何代码段需要等待人工响应。Aspose 组件经过严格测试，极其稳定。Aspose 组件已被[公司](https://about.aspose.com/customers)如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 等广泛使用。

## **可伸缩性/速度**
以下内容直接摘自上述引用的 Microsoft Article：

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Aspose 组件高度可伸缩，且速度极快。Office 应用程序并未设计用于同时被数百乃至数千用户使用，而 Aspose 组件正是为此而生。我们的组件是纯 C++ 解决方案，无论在单服务器、单应用程序，还是在负载均衡的 Web Form 环境中，都能毫无瑕疵地运行。

## **价格**
当应用程序使用 Microsoft Office 自动化时，必须为运行该应用程序的每台机器购买一份 Microsoft Office。许多情况下，应用程序需要创建或操作 Office 文件，但并不要求用户拥有 Microsoft Office。Aspose 提供了非常[性价比高](https://purchase.aspose.com/)且免版税的再分发许可证，允许无限量用户部署，无需担心授权问题。创建基于 Web 的应用程序时，需要了解 Microsoft Office 自动化组件既不面向服务器端定价，也不提供服务器端授权，因此没有合适的授权方案来部署使用 Microsoft Office 组件的 Web 应用程序。Aspose 同样为服务器端应用提供了非常[性价比高](https://purchase.aspose.com/)的解决方案。

## **功能**
Aspose 组件提供管理 Office 文件所需的一切，甚至更多。它们的设计理念是让开发者以最少的工作量实现最大的成果。与 Office 自动化不同，Aspose 组件提供了许多强大且节省时间的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/cpp/) 让开发者能够直接将 **DataTable** 或 **DataView** 导入到 Excel 文件中。[Aspose.Words](https://products.aspose.com/words/net/) 提供了类似功能，使开发者可以直接从任何 C++ 数据对象填充 Word（邮件合并）文档。Aspose 家族中的[每个组件](https://products.aspose.com/total/cpp/)都有其独特且强大的功能。购买 Aspose 组件的最佳收益在于可以获得我们开发团队的支持。我们的团队深知，如果贵公司需要某项功能，其他公司也很可能需要。虽然并非所有功能请求都能实现，但我们的团队在提供帮助时非常开明且灵活。这种思维方式帮助 Aspose 组件变得如此强大。如果您需要 Office 自动化对象的额外功能，获得它们被加入的机会非常、非常低。

## **结论**
{{% alert color="primary" %}} 

尽管本文已经覆盖了许多 Aspose 组件优于 Office 自动化的关键点，但实际优势远不止这些。本文仅重点阐述了最关键的要点。所有不同的 Aspose 组件均提供无风险、无需义务的[评估版本](https://downloads.aspose.com/slides/zh/cpp)。我们鼓励您利用该[评估](https://downloads.aspose.com/slides/zh/cpp)来更好地了解 Aspose 能为您的应用程序带来哪些帮助。 
{{% /alert %}}