---
title: Handle font substitution warnings while rendering
description: Receive reports when rendering substitutes a missing font.
type: docs
url: /features/font-rendering-warnings/
weight: 1250
feature_id: font-rendering-warnings
feature_group: rendering
translationKey: slides-feature-font-rendering-warnings
feature_catalogue_version: 2
feature_guides:
- /slides/net/presentation-warnings/
---

## **Overview**

Attach a rendering warning callback to receive information about reported font substitutions. The message can name the original font and the replacement choices, allowing your application to record what happened or decide how to continue.

## **FAQ**

**Does this report every change made during rendering?**

No. Do not treat the callback as a complete list of omitted media, objects or effects. It reports the warnings exposed by that rendering path.

## **Guides**

- [Handle Presentation Warnings in .NET](/slides/net/presentation-warnings/)

Related feature: [Record export and rendering warnings](/slides/features/export-warning-log/).
