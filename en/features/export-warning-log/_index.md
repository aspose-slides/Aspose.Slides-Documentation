---
title: Record export and rendering warnings
description: Collect warning messages from export and rendering operations.
type: docs
url: /features/export-warning-log/
weight: 1670
feature_id: export-warning-log
feature_group: warnings
translationKey: slides-feature-export-warning-log
feature_catalogue_version: 2
feature_guides:
- /slides/net/presentation-warnings/
---

## **Overview**

Attach warning callbacks to the relevant export or rendering options and record the messages your application receives. Reports can include warning types and descriptions of issues such as font substitution or particular formatting losses. Use the callbacks as part of your processing log.

## **FAQ**

**Does one callback attached at load time cover later exports?**

Attach it to the options for the operation you need to observe. Coverage varies by output path, and a load callback does not automatically receive later save warnings.

## **Guides**

- [Handle Presentation Warnings in .NET](/slides/net/presentation-warnings/)

Related feature: [Handle font substitution warnings while rendering](/slides/features/font-rendering-warnings/).
